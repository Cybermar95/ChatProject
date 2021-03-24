var MessageBox = document.getElementById("UserMessage");
MessageBox.value = "";
document.LastMsgID = 0;
document.Container = document.getElementById("Container");

function SendMessage() {

    var msgObject = { UserName: $("#User")[0].value, Text: $("#UserMessage")[0].value.split('\n').join('<br>') }

    if (msgObject.UserName === "" || msgObject.Text === "")
        return;

    $.ajax({
        // url: "https://localhost:2000/API/Message",
        url: "http://462495-co47915.tmweb.ru:8070/API/Message",
        type: "post",
        contentType: "application/json",
        data: JSON.stringify(msgObject),
        success: function (result, status, xhr) {

        },
        error: function (xhr, status, error) {

        }
    });

    var MessageBox = document.getElementById("UserMessage");
    MessageBox.value = "";
}

//asking server each 500 ms to update other messages in chat
function GetServerMessage() {
    //$.get("https://localhost:2000/API/Message" + "/" + document.LastMsgID, ServerResponse);
    $.get("http://462495-co47915.tmweb.ru:8070/API/Message" + "/" + document.LastMsgID, ServerResponse);
}
setInterval(GetServerMessage, 500);

//test function to reflect sevrer messages in chat window
function ServerResponse(result, responseStatus) {
    var container = document.getElementById("Container");


    for (var i = 0; i < result.length; i++) {
        var newMsgDiv = document.createElement('div');
        newMsgDiv.className = 'MsgStyle';
        newMsgDiv.innerHTML = result[i].userName + ": " + result[i].text;
        container.append(newMsgDiv);
    }


    if (result.length > 0) {
        document.LastMsgID = result[result.length - 1].id;
        container.scrollTop = container.scrollHeight;
    }
}

let isDown = false;
let startY;
let scrollDown;

document.Container.addEventListener('mousedown', (e) => {
    isDown = true;
    document.Container.classList.add('active');
    startY = e.pageY - document.Container.offsetTop;
    scrollDown = document.Container.scrollTop;
});

document.Container.addEventListener('mouseleave', () => {
    isDown = false;
    document.Container.classList.remove('active');
});

document.Container.addEventListener('mouseup', () => {
    isDown = false;
    document.Container.classList.remove('active');
});

document.Container.addEventListener('mousemove', (e) => {
    if (!isDown) return;
    e.preventDefault();
    const y = e.pageY - document.Container.offsetTop;
    const walk = (y - startY) * 6; //scroll-fast
    document.Container.scrollTop = scrollDown - walk;
    console.log(walk);
});

document.MessageBox = document.getElementById("UserMessage");

document.MessageBox.addEventListener('keypress', (e) => {
    if (e.code === 'Enter' && e.ctrlKey) {
        SendMessage();
    }
});