var audio = document.getElementById("music");
var btnPlay = document.getElementById("btnPlay");
var volValue = document.getElementById("volValue");
var volInfo = document.getElementById("volInfo");
var info = document.getElementById("info");
var song = document.getElementById("song");
var progress = document.getElementById("progress");
var book = document.getElementById("book");
console.log(audio.children[0].title);
//book.parentNode

song.addEventListener('change', function () {
    changeMusic(song.selectedIndex);
});

var option;
var tBook = book.children[1];
function UpdateMusic() {

    //移除目前下拉選單中的所有歌曲
    for (var j = song.children.length - 1; j >= 0; j--) {
        song.removeChild(song.children[j]);
    }

    //再抓我的歌本中的歌曲給下拉選單
    for (var i = 0; i < tBook.children.length; i++) {
        option = document.createElement("option");//<option></option>
        option.innerText = tBook.children[i].innerText;
        option.value = tBook.children[i].title;
        song.appendChild(option);
    }
    changeMusic(0);
}

function allowDrop(ev) {
    ev.preventDefault();  //停止物件預設行為
}

function drag(ev) {
    ev.dataTransfer.setData("IamAGoodBoy", ev.target.id);

}

function drop(ev) {
    ev.preventDefault();  //停止物件預設行為
    var data = ev.dataTransfer.getData("IamAGoodBoy");
    console.log(ev.target)
    if (ev.target.id == "")
        ev.target.appendChild(document.getElementById(data));
    else
        ev.target.parentNode.appendChild(document.getElementById(data));

}


//console.log(sBook.children.length);

var sBook = book.children[0];
for (var i = 0; i < sBook.children.length; i++) {
    sBook.children[i].draggable = "true";
    sBook.children[i].id = "song" + (i + 1);
    sBook.children[i].addEventListener('dragstart', function () {
        drag(event);
    });
    option = document.createElement("option");//<option></option>
    option.innerText = sBook.children[i].innerText;
    option.value = sBook.children[i].title;
    song.appendChild(option);
}
changeMusic(0);

function songBook() {
    book.className = book.className == "" ? "hide" : "";
}


//全曲循環
function setAllLoop() {

    info.children[2].innerText = info.children[2].innerText == "全曲循環" ? "狀態" : "全曲循環";


}

//隨機播放
function setRandom() {
    info.children[2].innerText = info.children[2].innerText == "隨機播放" ? "狀態" : "隨機播放";

}

//單曲循環
function setLoop() {

    info.children[2].innerText = info.children[2].innerText == "單曲循環" ? "狀態" : "單曲循環";

    //console.log(audio.loop);

}

//設定靜音
function setMuted() {
    audio.muted = !audio.muted;
}

//時間軸
function setTimeBar() {
    audio.currentTime = progress.value;
}

//上一首下一首
function changeSong(i) {
    var index = song.selectedIndex + i;
    //console.log(index);
    if (i == 1 && song.selectedIndex == song.options.length - 1)
        changeMusic(0);
    else if (i == -1 && song.selectedIndex == 0)
        changeMusic(song.options.length - 1);
    else
        changeMusic(index);
}


//歌曲切換
var musicObj, musicIndex = 0;
function changeMusic(i) {

    song.options[i].selected = true;
    audio.children[0].src = song.options[i].value;
    audio.children[0].title = song.options[i].innerText;
    audio.load();

    if (btnPlay.innerText == ";")
        Play();
}


//時間格式轉換
var min = 0, sec = 0, min2 = 0, sec2 = 0;
function getTimeFormat(timeSec) {
    min = parseInt(timeSec / 60);
    sec = parseInt(timeSec % 60);
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
}

//取得歌曲播放時間
function getDuration() {

    progress.max = parseInt(audio.duration);
    progress.value = parseInt(audio.currentTime);

    var w = (audio.currentTime / audio.duration * 100) + "%";
    progress.style.backgroundImage = "-webkit-linear-gradient(left,#b60000,#b60000 " + w + ", #c8c8c8 " + w + ",#c8c8c8)";

    info.children[1].innerText = getTimeFormat(audio.currentTime) + " / " + getTimeFormat(audio.duration);
    setTimeout(getDuration, 10);

    if (audio.currentTime == audio.duration) {
        if (info.children[2].innerText == "隨機播放") {
            var n = Math.floor(Math.random() * song.options.length);
            changeMusic(n);
        }
        else if (info.children[2].innerText == "全曲循環" && song.selectedIndex == song.options.length - 1) {

            changeMusic(0);
        }
        else if (info.children[2].innerText == "單曲循環") {
            //changeMusic(song.selectedIndex);
            changeSong(0);
        }
        else if (song.selectedIndex == song.options.length - 1) {
            Stop();
        }
        else
            changeSong(1);
    }
}


//播放與暫停功能
function Play() {
    //console.log(audio.loop);
    if (audio.paused) {
        audio.play();
        btnPlay.innerText = ";";
        info.children[0].innerText = "目前播放:" + audio.children[0].title;
        getDuration();

    }
    else {
        audio.pause();
        btnPlay.innerText = "4";
        info.children[0].innerText = "目前音樂暫停中";
    }
}

//停止播放功能
function Stop() {

    audio.pause();
    audio.currentTime = 0;
    btnPlay.innerText = "4";
    info.children[0].innerText = "目前音樂已停止播放";
}
//function Pause() {
//    audio.pause();
//}

//快轉與倒轉功能
function changeTime(t) {
    audio.currentTime += t;
}

//音量微調
function changeVolume(v) {
    //audio.volume += v;
    volValue.value = parseInt(volValue.value) + v;

    setVolume();
}
//音量調整
setVolume()
function setVolume() {
    volInfo.value = volValue.value;
    audio.volume = volValue.value / 100;

    var z = volValue.value + "%";
    volValue.style.backgroundImage = "-webkit-linear-gradient(left,#009d72,#009d72 " + z + ", #c8c8c8 " + z + ",#c8c8c8)";
}