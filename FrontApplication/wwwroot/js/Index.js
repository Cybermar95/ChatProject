//var ServerURL = "http://localhost:5001/";
var ServerURL= "http://462495-co47915.tmweb.ru:5001/",


function SignUp() {

    var userObject = { Name: $("#UserName")[0].value, Password: $("#Password")[0].value }

    if (userObject.Name === "" || userObject.Password === "")
        return;

    $.ajax({
        url: ServerURL+"Registration",
        type: "post",
        contentType: "application/json",
        data: JSON.stringify(userObject),
        success: function (result, status, xhr) {
            document.cookie = "Token=" + result.token + ";expires=Thu, 01 Jan 2077 00:00:00 UTC; path=/;";
            document.cookie = "Name=" + result.name + ";expires=Thu, 01 Jan 2077 00:00:00 UTC; path=/;";
            window.location.href = location.origin+ "/ChatPage";
        },
        error: function (xhr, status, error) {
            if (xhr.status == "409") {
                var signHeader = document.getElementById("SignHeader");
                signHeader.style.color = "#ff0000";
                signHeader.innerHTML = "This user is already exists :(";
            }
        }
    });

}

function LogIn() {
    var userObject = { Name: $("#UserName")[0].value, Password: $("#Password")[0].value }

    if (userObject.Name === "" || userObject.Password === "")
        return;

    $.ajax({
        url: ServerURL + "Authorize",
        type: "post",
        contentType: "application/json",
        data: JSON.stringify(userObject),
        success: function (result, status, xhr) {
            document.cookie = "Token=" + result.token + ";expires=Thu, 01 Jan 2077 00:00:00 UTC; path=/;";
            document.cookie = "Name=" + result.name + ";expires=Thu, 01 Jan 2077 00:00:00 UTC; path=/;";
            window.location.href = location.origin + "/ChatPage";
        },
        error: function (xhr, status, error) {
            var signHeader = document.getElementById("SignHeader");
            signHeader.style.color = "#ff0000";
            signHeader.innerHTML = xhr.status;
        }
    });
}
