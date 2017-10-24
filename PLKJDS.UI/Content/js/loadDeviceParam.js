function dateCompare(date1, date2) {
    date1 = date1.replace(/\-/gi, "-");
    date2 = date2.replace(/\-/gi, "-");
    var time1 = new Date(date1).getTime();
    var time2 = new Date(date2).getTime();
    if (time1 > time2) {
        return false;
    } else {
        return true;
    }
}


function getRootPath() {
    var resStr = "";
    var strFullPath = window.document.location.href;
  //  if (strFullPath.indexOf("localhost") == -1)
   // {
        var strPath = window.document.location.pathname;
        var pos = strFullPath.indexOf(strPath);
        var prePath = strFullPath.substring(0, pos);
        var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
        resStr=prePath + postPath
   /// }
    return resStr;
}

