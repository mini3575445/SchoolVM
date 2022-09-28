let audio = document.getElementById("music");
let btnPlay = document.getElementById("btnPlay");
let btnRange = document.getElementById("btnRange");
let divTest = document.getElementById("divTest");
let rangeVolume = document.getElementById("rangeVolume");
let textVolume = document.getElementById("textVolume");
let info = document.getElementById("info");
let song = document.getElementById("song");
let progress = document.getElementById("progress");
let book = document.getElementById("book");

song.addEventListener('change', function () {
    changeMusic(song.options.selectedIndex);
})
function hide() {       //顯示歌單
    book.className = book.className === "" ? "hide" : "";
}

function UpdateMusic() {    //更新歌單
    let option = Object;
    for (j = song.children.length - 1; j >= 0; j--) {
        song.removeChild(song.children[j]);
    }
    for (let i = 0; i < book.children[1].children.length; i++) {
        option = document.createElement("option");
        option.value = book.children[1].children[i].title;
        option.innerText = book.children[1].children[i].innerText;
        song.appendChild(option);
    }
    changeSong(0);
}

function allowDrop(ev) {    //停在某物件上面時
    ev.preventDefault();//停止物件預設行為
}

function drag(ev) {     //拉起來
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev) {		//放下來            
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    if (ev.target.id === "") ev.target.appendChild(document.getElementById(data));
    else ev.target.parentNode.appendChild(document.getElementById(data));
}

//我的歌本(把歌本Load進去Select中)
//移動物件部分可以參考==>W3C Drag and Drop API

function load() {
    let option = Object;
    for (let i = 0; i < book.children[0].children.length; i++) {

        book.children[0].children[i].addEventListener('dragstart', function () {
            drag(event);
        })
        book.children[0].children[i].id = "song" + (i + 1);
        book.children[0].children[i].draggable = "true";

        option = document.createElement("option");
        option.value = book.children[0].children[i].title;
        option.innerText = book.children[0].children[i].innerText;
        song.appendChild(option);
    }
}
load();

//全曲循環
function setAllLoop() {
    info.children[2].innerHTML === "" ? info.children[2].innerHTML = "全曲循環" : info.children[2].innerHTML = "";
}

//隨機播放
function setRandom() {
    //第一種
    info.children[2].innerHTML === "" ? info.children[2].innerHTML = "隨機播放" : info.children[2].innerHTML = "";
}

//單曲循環
function setLoop() {
    info.children[2].innerHTML === "" ? info.children[2].innerHTML = "單曲循環" : info.children[2].innerHTML = "";
}

//靜音
function setMuted() {
    audio.muted = !audio.muted;    //能不要用判斷式就不要用，盡量使用傳參數的方法    
    audio.muted?info.children[0].innerText = "目前靜音中":info.children[0].innerText = "";    
}

//*進度條事件
function setTimeBar() {
    audio.currentTime = progress.value * audio.duration;
}

//*歌曲切換        
function changeMusic(i) {
    if (i < 0) i = song.options.length - 1;
    else if (i === song.options.length) i = 0;
    song.options[i].selected = true;    //按下一首後，調整select
    audio.children[0].src = song.options[i].value;
    audio.children[0].title = song.options[i].innerText;
    audio.load();
    if (btnPlay.innerText === ";") Play();
}

//*上一首與下一首
function changeSong(n) {
    let index = song.options.selectedIndex + n;
    changeMusic(index);
}

//時間格式轉換
function getTimeFormat(timeSec) {
    let min = 0; let sec = 0;

    min = parseInt(timeSec / 60);
    sec = parseInt(timeSec % 60);
    min = min < 10 ? "0" + min : min;
    sec = sec < 10 ? "0" + sec : sec;

    return min + ":" + sec;
}

//取得歌曲播放時間            
function getDuration() {

    progress.value = audio.currentTime / audio.duration;
    info.children[1].innerText = getTimeFormat(audio.currentTime) + " / " + getTimeFormat(audio.duration);
    //console.log("audio.currentTime=" + audio.currentTime, "audio.duration=" + audio.duration)
    setTimeout(getDuration, 100);

    //判斷狀態
    if (audio.currentTime === audio.duration) {
        switch (info.children[2].innerHTML) {
            case "單曲循環":
                console.log("單曲循環");
                changeSong(0);
                break;

            case "隨機播放":
                console.log("隨機播放");
                let n = Math.floor(Math.random() * song.options.length);    //亂數(0~1，不包含1)*歌曲數目                
                console.log(Math.floor(n, Math.random(), song.options.length));
                changeMusic(n);
                break;

            case "全曲循環":
                if (song.selectedIndex === song.options.length - 1) {
                    console.log("全曲循環");
                    changeMusic(0);
                }
                else changeSong(1);
                break;


            case "":    //如果歌曲播完而且是最後一首，又沒有狀態的話
                changeSong(1);
                break;
        }

    }


}

//播放與暫停
function Play() {
    if (audio.paused) {
        audio.play();
        btnPlay.innerText = ";";
        info.children[0].innerText = "目前播放：" + audio.children[0].title;
        getDuration();
    }
    else {
        audio.pause();
        btnPlay.innerText = "4";
        info.children[0].innerText = "目前暫停中";
    }
}
//停止播放
function Stop() {
    audio.pause();
    audio.currentTime = 0;
    btnPlay.innerText = "4";
    info.children[0].innerText = "目前停止中";
}
//快轉與倒轉
function changeTime(t) {
    audio.currentTime += t;
}
//音量調整按鈕
function btnVolume(n) {
    rangeVolume.value = Number(rangeVolume.value) + n;
    RangeVolume();
}
//音量調整條
function RangeVolume() {
    audio.volume = rangeVolume.value;
    textVolume.value = audio.volume;
}