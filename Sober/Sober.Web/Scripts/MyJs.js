//时间格式转换
function DateTranslate(str) {
    var time = "";
    try {
        var t = new Date(parseInt(str.substr(6, 13)));
        time += t.getFullYear() + "-";
        time += AddZero(t.getMonth() + 1) + "-";
        time += AddZero(t.getDate()) + " ";
        time += AddZero(t.getHours()) + ":";
        time += AddZero(t.getMinutes()) + ":";
        time += AddZero(t.getSeconds()) + "";
        return time;
    }
    catch (e) {
        return time;
    }
}
//日期不满10加0
function AddZero(input) {
    if (parseInt(input) < 10) {
        input = "0" + input;
    }
    return input;
}