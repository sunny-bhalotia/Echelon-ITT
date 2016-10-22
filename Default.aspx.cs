using System;
using System.Net.Http;
using System.Web.UI;
using System.Text.RegularExpressions;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "ajax" && Request.Form["FirstName"] != null)
        {
            //Saving the query in session. Variables are posted by ajax.
            Session["FirstName"] = Request.Form["FirstName"] ?? "";
        }
        if (Request.QueryString["mode"] != null && Request.QueryString["mode"] == "ajax" && Request.Form["stars"] != null)
        {
            Session["stars"] = Request.Form["stars"] ?? "";
            Response.Write(Session["stars"]);
        } 
    }   

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var url = "http://127.0.0.1:5000/todo/api/v1.0/tasks?query=" + Session["FirstName"];
        Response.Write(url);
        string x = null;
        Div2.InnerHtml = Session["FirstName"].ToString();
        var client = new HttpClient();
        var task = client.GetAsync(url);
        x = task.Result.Content.ReadAsStringAsync().Result;
        while (x == null) ;
        string[] tokens = x.Split(new[] { "--::--" }, StringSplitOptions.None);
        string[] s = tokens[0].Split(new[] { "::::" }, StringSplitOptions.None);
        string result = textSummarizer(s[1]);
        Div3.InnerHtml = result;
        Div2.InnerHtml = s[0];

        s = tokens[1].Split(new[] { "::::" }, StringSplitOptions.None);
        result = textSummarizer(s[1]);
        Div6.InnerHtml = result;
        Div5.InnerHtml = s[0];

        s = tokens[2].Split(new[] { "::::" }, StringSplitOptions.None);
        result = textSummarizer(s[1]);
        Div9.InnerHtml = result;
        Div8.InnerHtml = s[0];
        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        var star = Session["stars"];
        Response.Write(star);
    }



    static string stpHandler(string para)
    {
        string[] stopWordsList = new string[] {

                                                              "a",
                                                              "about",
                                                              "above",
                                                              "across",
                                                              "afore",
                                                              "aforesaid",
                                                              "after",
                                                              "again",
                                                              "against",
                                                              "ago",
                                                              "all",
                                                              "almost",
                                                              "alone",
                                                              "along",
                                                              "alongside",
                                                              "already",
                                                              "also",
                                                              "although",
                                                              "always",
                                                              "am",
                                                              "amid",
                                                              "amidst",
                                                              "among",
                                                              "amongst",
                                                              "an",
                                                              "and",

                                                              "another",
                                                              "any",
                                                              "anybody",
                                                              "anyone",
                                                              "anything",
                                                              "are",
                                                              "aren't",
                                                              "around",
                                                              "as",


                                                              "at",

                                                              "away",

                                                              "back",

                                                              "barring",
                                                              "be",
                                                              "because",
                                                              "been",
                                                              "before",
                                                              "behind",
                                                              "being",
                                                              "below",
                                                              "beneath",
                                                              "beside",
                                                              "besides",
                                                              "best",
                                                              "better",
                                                              "between",

                                                              "beyond",
                                                              "both",
                                                              "but",
                                                              "by",

                                                              "can",
                                                              "cannot",
                                                              "can't",
                                                              "certain",

                                                              "close",
                                                              "concerning",
                                                              "considering",

                                                              "could",
                                                              "couldn't",
                                                              "couldst",

                                                              "dare",
                                                              "dared",
                                                              "daren't",
                                                              "dares",
                                                              "daring",
                                                              "despite",
                                                              "did",
                                                              "didn't",
                                                              "different",
                                                              "directly",
                                                              "do",
                                                              "does",
                                                              "doesn't",
                                                              "doing",
                                                              "done",
                                                              "don't",

                                                              "doth",
                                                              "down",
                                                              "during",
                                                              "durst",

                                                              "each",
                                                              "early",
                                                              "either",

                                                              "english",
                                                              "enough",

                                                              "even",
                                                              "ever",
                                                              "every",
                                                              "everybody",
                                                              "everyone",
                                                              "everything",
                                                              "except",
                                                              "excepting",

                                                              "failing",
                                                              "far",
                                                              "few",
                                                              "first",
                                                              "five",
                                                              "following",
                                                              "for",
                                                              "four",
                                                              "from",

                                                              "gonna",
                                                              "gotta",

                                                              "had",
                                                              "hadn't",
                                                              "hard",
                                                              "has",
                                                              "hasn't",
                                                              "hast",
                                                              "hath",
                                                              "have",
                                                              "haven't",
                                                              "having",
                                                              "he",
                                                              "he'd",
                                                              "he'll",
                                                              "her",
                                                              "here",
                                                              "here's",
                                                              "hers",
                                                              "herself",
                                                              "he's",
                                                              "high",
                                                              "him",
                                                              "himself",
                                                              "his",
                                                              "home",
                                                              "how",
                                                              "howbeit",
                                                              "however",
                                                              "how's",

                                                              "id",
                                                              "if",
                                                              "ill",
                                                              "i'm",
                                                              "immediately",
                                                              "important",
                                                              "in",
                                                              "inside",
                                                              "instantly",
                                                              "into",
                                                              "is",
                                                              "isn't",
                                                              "it",
                                                              "it'll",
                                                              "it's",
                                                              "its",
                                                              "itself",
                                                              "i've",

                                                              "just",


                                                              "large",
                                                              "last",
                                                              "later",
                                                              "least",
                                                              "left",
                                                              "less",
                                                              "lest",
                                                              "let's",
                                                              "like",
                                                              "likewise",
                                                              "little",
                                                              "living",
                                                              "long",

                                                              "many",
                                                              "may",
                                                              "mayn't",
                                                              "me",
                                                              "mid",
                                                              "midst",
                                                              "might",
                                                              "mightn't",
                                                              "mine",
                                                              "minus",
                                                              "more",
                                                              "most",
                                                              "much",
                                                              "must",
                                                              "mustn't",
                                                              "my",
                                                              "myself",

                                                              "near",
                                                              "'neath",
                                                              "need",
                                                              "needed",
                                                              "needing",
                                                              "needn't",
                                                              "needs",
                                                              "neither",
                                                              "never",
                                                              "nevertheless",
                                                              "new",
                                                              "next",
                                                              "nigh",
                                                              "nigher",
                                                              "nighest",

                                                              "no",
                                                              "no-one",
                                                              "nobody",
                                                              "none",
                                                              "nor",
                                                              "not",
                                                              "nothing",
                                                              "notwithstanding",
                                                              "now",

                                                              "of",
                                                              "off",
                                                              "often",
                                                              "on",
                                                              "once",
                                                              "one",
                                                              "oneself",
                                                              "only",
                                                              "onto",
                                                              "open",
                                                              "or",
                                                              "other",
                                                              "otherwise",
                                                              "ought",
                                                              "oughtn't",
                                                              "our",
                                                              "ours",
                                                              "ourselves",
                                                              "out",
                                                              "outside",
                                                              "over",
                                                              "own",

                                                              "past",
                                                              "pending",
                                                              "per",
                                                              "perhaps",
                                                              "plus",
                                                              "possible",
                                                              "present",
                                                              "probably",
                                                              "provided",
                                                              "providing",
                                                              "public",

                                                              "qua",
                                                              "quite",

                                                              "rather",

                                                              "real",
                                                              "really",
                                                              "respecting",
                                                              "right",
                                                              "round",

                                                              "same",

                                                              "save",
                                                              "saving",
                                                              "second",
                                                              "several",
                                                              "shall",
                                                              "shalt",
                                                              "shan't",
                                                              "she",
                                                              "shed",
                                                              "shell",
                                                              "she's",
                                                              "short",
                                                              "should",
                                                              "shouldn't",
                                                              "since",
                                                              "six",
                                                              "small",
                                                              "so",
                                                              "some",
                                                              "somebody",
                                                              "someone",
                                                              "something",
                                                              "sometimes",
                                                              "soon",
                                                              "special",
                                                              "still",
                                                              "such",

                                                              "supposing",
                                                              "sure",

                                                              "than",
                                                              "that",
                                                              "that'd",
                                                              "that'll",
                                                              "that's",
                                                              "the",
                                                              "thee",
                                                              "their",
                                                              "theirs",
                                                              "their's",
                                                              "them",
                                                              "themselves",
                                                              "then",
                                                              "there",
                                                              "there's",
                                                              "these",
                                                              "they",
                                                              "they'd",
                                                              "they'll",
                                                              "they're",
                                                              "they've",
                                                              "thine",
                                                              "this",

                                                              "those",
                                                              "thou",
                                                              "though",
                                                              "three",
                                                              "thro'",
                                                              "through",
                                                              "throughout",
                                                              "thru",
                                                              "thyself",
                                                              "till",
                                                              "to",
                                                              "too",
                                                              "today",
                                                              "together",
                                                              "too",
                                                              "touching",
                                                              "toward",
                                                              "towards",
                                                              "true",
                                                              "'twas",
                                                              "'tween",
                                                              "'twere",
                                                              "'twill",
                                                              "'twixt",
                                                              "two",
                                                              "'twould",

                                                              "under",
                                                              "underneath",
                                                              "unless",
                                                              "unlike",
                                                              "until",
                                                              "unto",
                                                              "up",
                                                              "upon",
                                                              "us",
                                                              "used",
                                                              "usually",

                                                              "versus",
                                                              "very",
                                                              "via",
                                                              "vice",
                                                              "vis-a-vis",

                                                              "wanna",
                                                              "wanting",
                                                              "was",
                                                              "wasn't",
                                                              "way",
                                                              "we",
                                                              "we'd",
                                                              "well",
                                                              "were",
                                                              "weren't",
                                                              "wert",
                                                              "we've",
                                                              "what",
                                                              "whatever",
                                                              "what'll",
                                                              "what's",
                                                              "when",
                                                              "whencesoever",
                                                              "whenever",
                                                              "when's",
                                                              "whereas",
                                                              "where's",
                                                              "whether",
                                                              "which",
                                                              "whichever",
                                                              "whichsoever",
                                                              "while",
                                                              "whilst",
                                                              "who",
                                                              "who'd",
                                                              "whoever",
                                                              "whole",
                                                              "who'll",
                                                              "whom",
                                                              "whore",
                                                              "who's",
                                                              "whose",
                                                              "whoso",
                                                              "whosoever",
                                                              "will",
                                                              "with",
                                                              "within",
                                                              "without",
                                                              "wont",
                                                              "would",
                                                              "wouldn't",
                                                              "wouldst",

                                                              "yet",
                                                              "you",
                                                              "you'd",
                                                              "you'll",
                                                              "your",
                                                              "you're",
                                                              "yours",
                                                              "yourself",
                                                              "yourselves",
                                                              "you've",

        };
        for (int i = 0; i < stopWordsList.Length; i++)
        {
            int index, j;
            char[] wordUpper = stopWordsList[i].ToCharArray();
            string wordToRemoveUpper = wordUpper[0].ToString().ToUpper();
            for (j = 1; j < wordUpper.Length; j++)
            {
                wordToRemoveUpper += wordUpper[j].ToString();
            }
            string wordToRemove = " " + stopWordsList[i] + " ";
            while ((index = para.IndexOf(wordToRemove)) != -1 || (index = para.IndexOf(wordToRemoveUpper)) != -1)
            {
                para = para.Remove(index, stopWordsList[i].Length + 1);
            }
        }


        return para;
    }
    static string textSummarizer(string para)
    {
        int i;
        string[] unaltered = Regex.Split(para, @"(?<!\w\.\w.)(?<![A-Z][a-z]\.)(?<=\.|\?)\s*");
        para = stpHandler(para);
        string[] sentences = Regex.Split(para, @"(?<!\w\.\w.)(?<![A-Z][a-z]\.)(?<=\.|\?)\s*");
        double[] sf_2 = new double[sentences.Length];
        double[] sf_8 = new double[sentences.Length];
        double[] sf_3 = new double[sentences.Length];
        double[] sf_6 = new double[sentences.Length];
        double[] total = new double[sentences.Length];
        sentenceFeature3(sentences, sf_3, para);
        sentenceFeature2(sentences, sf_2);
        sentenceFeature8(sentences, sf_8);
        sentenceFeature6(sentences, sf_6);
        for (i = 0; i < sentences.Length; i++)
        {
            total[i] = sf_2[i] + sf_3[i] + sf_8[i] + sf_6[i];
        }
        /*for (i = 0; i < sentences.Length; i++)
        {
            Debug.WriteLine("sentence feature 2 " + sf_2[i] + "sentence feature 3 " + sf_3[i] + "sentence feature 8 " + sf_8[i] + "sentence feature 6 " + sf_6[i]);
            Debug.WriteLine(total[i]);
        }*/
        int maxInd = 0, lineDispCount = 5;
        string result = " ";
        while (lineDispCount-- > 0)
        {
            for (i = 0; i < sentences.Length; i++)
            {
                if (total[maxInd] < total[i])
                {
                    maxInd = i;
                }

            }
            result += unaltered[maxInd];
            total[maxInd] = 0;
        }
        return result;
    }

    static void sentenceFeature2(string[] sentences, double[] sf_2)
    {
        int maxIndex = 0;
        int i = 0;
        foreach (string sentence in sentences)
        {

            sf_2[i] = sentence.Length;
            if (sf_2[i] < 18)
            {
                sf_2[i] = -200;
            }
            if (sentence.Length > sf_2[maxIndex])
            {
                maxIndex = i;
            }
            i++;
        }

        double maxLength = sf_2[maxIndex];
        for (i = 0; i < sf_2.Length; i++)
        {
            sf_2[i] /= maxLength;
        }
    }
    static void sentenceFeature8(string[] sentences, double[] sf_8)
    {
        int i = 0;
        foreach (string sentence in sentences)
        {
            double digCount = 0;
            foreach (char c in sentence)
            {
                if (char.IsDigit(c))
                {
                    digCount++;
                }
            }
            sf_8[i] = digCount / sentence.Length;
            i++;
        }

    }

    static void sentenceFeature3(string[] sentences, double[] sf_3, string para)
    {
        int i = 0;
        double max = 0;
        try {
            foreach (string sentence in sentences)
            {
                var splitted = sentence.Split(' ');
                sf_3[i] = 0;
                for (int start = 0; start < splitted.Length; start++)
                {
                    string word = splitted[start];
                    int sentFreq = 0;
                    int termFreq = 0;


                    foreach (Match match in Regex.Matches(para, word))
                    {
                        termFreq++;
                    }
                    foreach (string line in sentences)
                    {
                        if (line.IndexOf(word) != -1)
                        {
                            sentFreq++;
                        }
                    }
                    if (sentFreq != 0)
                        sf_3[i] += termFreq * (Math.Log(sentences.Length / sentFreq));

                }
                if (sf_3[i] > max)
                {
                    max = sf_3[i];
                }
                i++;
            }
            for (i = 0; i < sentences.Length; i++)
            {
                sf_3[i] = sf_3[i] / max;
            } 
        }
        catch (Exception) { }

    }

    static void sentenceFeature6(string[] sentences, double[] sf_6)
    {
        int i, count, totCount = 0, j = 0;
        foreach (string sentence in sentences)
        {
            count = 0;
            for (i = 0; i < sentence.Length - 2; i++)
            {
                if ((sentence[i + 1] >= 65 && sentence[i + 1] <= 90) || (sentence[i + 1] >= 97 && sentence[i + 1] <= 122))
                {

                }
                else
                {
                    continue;
                }
                if (sentence[i] == ' ' && sentence[i + 1].ToString().Equals(sentence[i + 1].ToString().ToUpper()) && sentence[i + 2] != ' ')
                {
                    count++;
                    totCount++;
                }
            }
            sf_6[j++] = count;

        }
        for (j = 0; j < sentences.Length; j++)
        {
            sf_6[j] /= totCount;
        }
    }
}