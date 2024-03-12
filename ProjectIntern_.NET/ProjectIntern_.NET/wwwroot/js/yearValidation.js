var getYear = document.getElementById("yearGen").text;
var min = getYear + '-' + 1 + '-' + 1;
var max = getYear + '-' + 12 + '-' + 31;
document.getElementById("denpyoDateFrom").setAttribute("max", max);
document.getElementById("denpyoDateFrom").setAttribute("min", min);
document.getElementById("uketukeDateFrom").setAttribute("max", max);
document.getElementById("uketukeDateFrom").setAttribute("min", min);
