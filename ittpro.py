"""Cloud Foundry test"""
from flask import Flask, request
import cf_deployment_tracker
import os
import urllib
from bs4 import BeautifulSoup
from google import search
import sqlite3,datetime
import sys

# Emit Bluemix deployment event
cf_deployment_tracker.track()

app = Flask(__name__)



def extract_text_from_html(weblink):

	#url = "https://www.tutorialspoint.com/python/list_len.htm"
	url=weblink
	html = urllib.urlopen(url).read()
	soup = BeautifulSoup(html,"html5lib")

	# kill all script and style elements
	for script in soup(["script", "style"]):
	    script.extract()    # rip it out

	# get text
	text = soup.get_text()


	# break into lines and remove leading and trailing space on each
	lines = (line.strip() for line in text.splitlines())

	# break multi-headlines into a line each
	chunks = (phrase.strip() for line in lines for phrase in line.split("  "))

	# drop blank lines
	text = '\n'.join(chunk for chunk in chunks if chunk)

	#print(text.encode('utf-8'))
	x=text.encode('utf-8')
	finaltext=x.split("\n")
	texttoreturn=""
	for i in finaltext:
		if len(i)>15 and i.find(".")!=-1 and i.find("<")!=0 and i.find("Terms of Service and Privacy Policy")==-1:
			texttoreturn+= i+'\n'
	return texttoreturn


def get_links( search_query):
	list1=[]
	for url in search(search_query, stop=10):
		if url.count('/')>=4 and url[len(url)-1]!='/': 
			list1.append(url.encode('utf-8'))
	#print list1
	return list1


@app.route('/todo/api/v1.0/tasks', methods=['GET'])
def hello_world():
	query=request.args.get('query')
	dbcount=0;
	now = datetime.datetime.now()

	reload(sys)  
	sys.setdefaultencoding('utf8')
	conn=sqlite3.connect('mydata.db')
	tablename='mytable'+str(now.strftime("%Y-%m-%d"));
	conn.execute('create table if not exists '+tablename.replace("-","")+' ( weblink text primary key not null, data text );')
	cursor=conn.execute('select data from '+tablename.replace("-","")+' where weblink ="'+query+'";')
	myresult=""
	for row in cursor:
		dbcount=dbcount+1
		myresult=row[0]
	
	if dbcount > 0 :
		conn.close()
		with open(str(row[0]), 'r') as content_file:
   			content = content_file.read()
		#print content
		return ' ' + str(content)
	else:
		search_result=get_links(str(query))
		x=''
		r=0
		for i in search_result:
			if r==4:
				break
			if i.find("wiki")==-1:
				r+=1
				x+=i+'::::'+ extract_text_from_html(i)+'--::--\r\n'
		conn.execute('insert into '+tablename.replace("-","")+' values ("'+query+'","'+query+'.txt");')
		conn.commit()
		conn.close()
		fo=open(query+".txt","wb")
		fo.write(str(x))
		fo.close()
		return ' ' + str(x)

    
if __name__ == '__main__':
    app.run(debug=True)
