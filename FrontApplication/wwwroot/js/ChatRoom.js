/** Конструктор чат комнаты. */
function CreateNewChatRoom(roomPanel, serverURL)
{
    this.ServerURL = serverURL;

    this.LastMsgID = 0;

    this.RoomID = 1;

    this.OnlineUsers;




    /** Время в милисекундах для обновления чата. */
    this.UpdateTime = 2000;

    /** Токен доступа к серверу. */
    this.AccessToken = GetCookie("Token");

    /** Токен доступа к серверу. */
    this.UserName = GetCookie("Name");

    /** Создание Html элементов чат комнаты. */
    function CreateRoomElements(roomPanel)
    {
        this.MsgPanel = document.createElement("div");
        this.MsgPanel.className = "MsgPanel";

        let InputPanel = document.createElement("div");
        InputPanel.className = "InputPanel";

        this.MsgInput = document.createElement("textarea");
        this.MsgInput.className = "MsgInput";
        this.MsgInput.placeholder = "Write a message...";

        this.SendButton = document.createElement("button");
        this.SendButton.className = "SendButton";
        this.SendButton.innerHTML = "Send";
        this.SendButton.ChatRoom = this;

        InputPanel.append(this.MsgInput);
        InputPanel.append(this.SendButton);

        roomPanel.append(this.MsgPanel);
        roomPanel.append(InputPanel);
    }
    CreateRoomElements.call(this, roomPanel);

    /** Получение онлайн пользователей комнаты. */
    this.GetOnlineUsers = function ()
    {
        var context = this;
        $.ajax({
            url: this.ServerURL + "API/RoomOnlineStatus" + "/" + this.RoomID + "?name=" + this.UserName,
            type: "get",
            headers: { 'AccessToken': this.AccessToken },
            success: function (data) {
                context.RefreshRoomOnlinePanel(data);
            },
            error: function (xhr, status, error) {
                if (xhr.status == "401") {
                    window.location.href = location.origin;
                }
            }
        });
    }

    /** Обновление списка пользователей онлайн */
    this.RefreshRoomOnlinePanel = function (data)
    {
        this.OnlineUsers = data;
        console.log(JSON.stringify(this.OnlineUsers));
    }

    /** Запустить обновление онлайн. */
    this.StartUpdateOnlinePanel = function (context) {
        this.UpdateOnlineUsersInterval = setInterval(function () {
            context.GetOnlineUsers.call(context)
        }, this.UpdateTime)
    };

    /** Остановить обновление онлайн. */
    this.StopUpdateOnlinePanel = function () {
        clearInterval(this.UpdateOnlineUsersInterval);
    };

    // Запуск обновления онлайн.
    this.StartUpdateOnlinePanel(this);











    /** Получение новых сообщений с сервера. */
    this.GetNewMsg = function ()
    {

        var context = this;
        $.ajax({
            url: this.ServerURL + "API/Message" + "/" + this.LastMsgID,
            type: "get",
            headers: { 'AccessToken': this.AccessToken },
            success: function (data) {
                context.AddNewMsgToPanel(data);
            },
            error: function (xhr, status, error) {
                if (xhr.status == "401") {
                    window.location.href = location.origin;
                }
            }
        });
    }

    /** Добавление новых сообщений в чат. */
    this.AddNewMsgToPanel = function (data) {

        for (var i = 0; i < data.length; i++)
        {
            let newMsgDiv = document.createElement('div');
            newMsgDiv.className = 'MsgStyle';
            newMsgDiv.innerHTML = data[i].userName + ": " + data[i].text;
            this.MsgPanel.append(newMsgDiv);
        }

        if (data.length > 0) {
            this.LastMsgID = data[data.length - 1].id;
            this.MsgPanel.scrollTop = this.MsgPanel.scrollHeight;
        }
    }

    /** Отправка сообщения на сервер. */
    this.SendMsg = function () {
        var msgObject = { UserName: this.UserName, Text: this.MsgInput.value.split('\n').join('<br>') }

        if (msgObject.UserName.trim() == "" || msgObject.Text.trim() == "")
            return;

        $.ajax({
            url: this.ServerURL + "API/Message",
            type: "post",
            contentType: "application/json",
            data: JSON.stringify(msgObject),
        });

        this.MsgInput.value = "";
    }

    /** Запустить обновление чата. */
    this.StartUpdateMsgPanel = function (context) {
        this.UpdateMsgPanelInterval = setInterval(function () {
            context.GetNewMsg.call(context)
        }, this.UpdateTime)
    };

    /** Остановить обновление чата. */
    this.StopUpdateMsgPanel = function () {
        clearInterval(this.UpdateMsgPanelInterval);
    };

    // Запуск обновления чат комнаты.
    this.StartUpdateMsgPanel(this);

    this.SendButton.onclick = function () { this.ChatRoom.SendMsg.call(this.ChatRoom)};

    this.MsgInput.addEventListener('keypress', (e) => {
        if (e.code === 'Enter' && e.ctrlKey) {
            this.SendMsg();
        }
    });
}
