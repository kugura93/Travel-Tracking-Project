// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function onfocusType(x) {
	var getYear = document.getElementById("yearGen").value;
	x.type = 'date';
	x.min = getYear + '-01-01';
	x.max = getYear + '-12-31';
}

function onfocusTypeLimitless(x) {
	x.type = 'date';
}