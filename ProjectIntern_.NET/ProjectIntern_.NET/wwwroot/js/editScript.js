sumCash();

function backHome(newloc) {
    window.location.assign(newloc);
}

function assignLocation(newloc, maxId) {
    window.location.assign(newloc + '/' + maxId);
}

function sumCash() {
    //var table = document.getElementById("dbRecords");
    //let sumCash = Array.from(table.rows).slice(6).reduce((total, row) => {
    //    return total + parseInt(row.cells[6].innerHTML);
    //}, 0);

    var cell = document.getElementsByClassName("count-me");
    var sumCash = 0;
    var i = 0;
    while (cell[i] != undefined) {
        sumCash += parseInt(cell[i].innerHTML);
        i++;
    }

    document.getElementById("sumCash").innerHTML = parseInt(sumCash);
    console.log(parseInt(sumCash));
}

function getIdToEdit(id) {
    window.location.assign = 'edit' + id 
}

