$(function () {
    $("#BlogForm").submit(function(data) {
        console.log(data);
    });
});

function SelectBlogPost(id) {
    
    var currentId = $("#Id").val();

    //if click already selected ignore
    if (currentId == id) return;

    SetSelectionStyles(id);
    SendBlogPostGetRequest(id);

    //set current id
    $("#Id").val(id);
}

function SendBlogPostGetRequest(id) {
    var url = $("#" + id).data("url");
    $.get(url, HandleBlogPostGetRequest);   
}

function HandleBlogPostGetRequest(data) {
    var title = "";
    var summary = "";
    var body = "";
    if (data !== "") {
        title = data.Title;
        summary = data.Summary;
        body = data.Body;
    }
    $("#Title").val(title);
    $("#Summary").val(summary);
    $("#Body").val(body);
}

function SetSelectionStyles(id) {
    var selectedBlogId = $("#Id").val();

    $("#" + selectedBlogId).toggleClass("Selected");
    $("#" + id).toggleClass("Selected");
}

function SavePostSuccessHandler(data) {
    console.log(data.success);
}