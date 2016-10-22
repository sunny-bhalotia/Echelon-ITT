<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />


    <!--Polymer Elements-->

     <script src="bower_components/webcomponentsjs/webcomponents-lite.js"></script>
	<link rel="import" href="bower_components/paper-styles/demo-pages.html" />
    <link rel="import" href="bower_components/polymer/polymer.html" />
    <link rel="import" href="bower_components/paper-icon-button/paper-icon-button.html" />
    <link rel="import" href="bower_components/paper-card/paper-card.html" />
    <link rel="import" href="bower_components/paper-checkbox/paper-checkbox.html" />
    <link rel="import" href="bower_components/paper-item/paper-item.html" />
    <link rel="import" href="bower_components/paper-input/paper-input.html" />
    <link rel="import" href="bower_components/paper-input/paper-input-container.html" />
    <link rel="import" href="bower_components/paper-input/paper-input-error.html" />
    <link rel="import" href="bower_components/paper-input/demo/ssn-input.html" />
    <link rel="import" href="bower_components/paper-input/demo/ssn-validator.html" />
    <link rel="import" href="bower_components/paper-icon-button/paper-icon-button.html" />
    <link rel="import" href="bower_components/paper-elements/paper-elements.html" />
    <link rel="import" href="bower_components/paper-material/paper-material.html" />
    <link rel="import" href="bower_components/iron-icons/iron-icons.html" />
    <link rel="import" href="bower_components/paper-fab/paper-fab.html" />
    <link rel="import" href="bower_components/paper-button/paper-button.html" />
    <link rel="import" href="bower_components/paper-more-button/paper-more-button.html" />
    <link rel="import" href="bower_components/paper-search/paper-search.html" />
    <link href="Content/bootstrap.min.css"rel="stylesheet" />
    
    
    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <title>Search Page</title>

    <!--Css-link -->
    <link rel="stylesheet" href="css/SearchPage.css" />

    <!--Custom Styles For Paper Card -->

    <style is="custom-style">
                
  paper-card.rate { @apply(--layout-horizontal); }
  .rate-image {
    width: 100px;
    height: 170px;
    background: url('./donuts.png');
    background-size: cover;
  }
  .rate-content {
    @apply(--layout-flex);
    float: left;
  }
  .rate-header { @apply(--paper-font-headline); }
  .rate-name { color: var(--paper-grey-600); margin: 10px 0; }

    paper-icon-button.thumb-icon {
    color: var(--paper-black-500);
    --paper-icon-button-ink-color: var(--paper-indigo-500);
  }
  paper-icon-button.thumb-icon:hover {
    color:blue;
  }


.cards-cst {
    margin-top:20px;
    margin-bottom:20px;
    display:none;
}
  </style>
</head>

<body>
    <form id="form1" runat="server">
    <div>
		<template is="dom-bind">
			<paper-search-panel
				placeholder="Search for anything..."
				hide-filter-button="true"
				search="{{search}}"
                no-Results-Text=""
				on-change-request-params="loadData">

				<div fixed>
                  <asp:Button ID="btnSearch" runat="server" CssClass="btn-primary btn btn-sm cstm-btn" Text="Submit" OnClick="btnSearch_Click" ></asp:Button>
                  <asp:Button ID="btnCheck" runat="server" CssClass="hidden" Text="" OnClick="btnCheck_Click"></asp:Button>
				</div>
			</paper-search-panel>

		</template>
    </div>


        <div fixed>

<!--article cards 1-4-->
<div class="cards-cst">
<paper-card class="rate">
  <div class="rate-content">
    <div class="card-content">
      <div class="rate-header" id="Div1" runat="server">Article</div>
      <div class="rate-name" runat="server" id="Div2">Query</div>
      <div runat="server" id="Div3">Content</div>
    </div>
    <div class="card-actions">
      <paper-icon-button class="thumb-icon" id="btn1_1" icon="thumb-up" onclick="fun1('#btn1_1')"></paper-icon-button>
      <paper-icon-button class="thumb-icon" id="btn1_2" icon="thumb-down"></paper-icon-button>
    </div>
  </div>
  <div class="rate-image"></div>
</paper-card>
</div>

<div class="cards-cst">
<paper-card class="rate" id="pc2">
  <div class="rate-content">
    <div class="card-content">
      <div class="rate-header" id="Div4" runat="server">Article</div>
      <div class="rate-name" runat="server" id="Div5">Query</div>
      <div runat="server" id="Div6">Content</div>
    </div>
    <div class="card-actions">
      <paper-icon-button class="thumb-icon" id="btn2_1" icon="thumb-up" onclick="fun1('#btn2_1')"></paper-icon-button>
      <paper-icon-button class="thumb-icon" id="btn2_2" icon="thumb-down"></paper-icon-button>
    </div>
  </div>
  <div class="rate-image"></div>
</paper-card>
</div>

<div class="cards-cst">
<paper-card class="rate">
  <div class="rate-content">
    <div class="card-content">
      <div class="rate-header" id="Div7" runat="server">Article</div>
      <div class="rate-name" runat="server" id="Div8">Query</div>
      <div runat="server" id="Div9">Content</div>
    </div>
    <div class="card-actions">
      <paper-icon-button class="thumb-icon" id="btn3_1" icon="thumb-up" onclick="fun1('#btn3_1')"></paper-icon-button>
      <paper-icon-button class="thumb-icon" id="btn3_2" icon="thumb-down"></paper-icon-button>
    </div>
  </div>
  <div class="rate-image"></div>
</paper-card>
</div>

<div class="cards-cst">
<paper-card class="rate">
  <div class="rate-content">
    <div class="card-content">
      <div class="rate-header" id="Div10" runat="server">Article</div>
      <div class="rate-name" runat="server" id="Div11">Query</div>
      <div runat="server" id="Div12">Content</div>
    </div>
    <div class="card-actions">
      <paper-icon-button class="thumb-icon" id="btn4_1" icon="thumb-up" onclick="fun1('#btn4_1')"></paper-icon-button>
      <paper-icon-button class="thumb-icon" id="btn4_2" icon="thumb-down"></paper-icon-button>
    </div>
  </div>
  <div class="rate-image"></div>
</paper-card>
</div>

	</div>

<script>
	    var scope = document.querySelector("template[is=dom-bind]");
	    scope.loadData = function () {
        // Post the Query to the Server
	        var query = scope.search;
            $.post(document.URL+'?mode=ajax', 
                 {'FirstName':query,
                 });
	    };

	    function AnotherFunction() {
	        $('.cards-cst').css('display', 'block');
	    }

	    function fun1(sel) {
	        $(sel).css('color', 'blue');
	        $.post(document.URL + '?mode=ajax',
              {
                'stars': '1',
              });
	        document.getElementById("btnCheck").click();
	        document.getElementById("btnSearch").click();
	    }




</script>

    </form>
</body>
</html>
