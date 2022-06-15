async function callController(URL, data1) {
   
  //  var Result = await $('.pre-loader').show();
    $.ajax({
        'type': "POST",
        'global': true,
        'dataType': 'json',
        'async': false,
        'url': URL,
        'data': data1,
        'success': function (data) {

            if (data == "SEXP") {
                window.location.href = '@Url.Action("Index", "Login")';
                return false;
            }
            Result = (data);
        },
        'error': function (e) {
            Result = "error";
            //alert(e);
            $("#pageloader").fadeOut("slow");
        },
    });

    return Result;

}

function Dropdown(data) {
    var rows = '<option value="0">Select</option>';
    try {
        for (var i = 0; i < data.length;i++)
            rows += '<option value="' + data[i].value + '">' + data[i].text +'</option>';
    } catch {

    }
    return rows;
}

function ActionsButtons(ID) {
    var rows = '<ul>';
    rows += '<div class="nav-item dropdown">';
    rows += '<a class="nav-link" data-toggle="dropdown" href="#">';
    rows += '<i class="fas fa-ellipsis-h"></i>';
    rows += '</a>';
    rows += '<div class="dropdown-menu dropdown-menu-sm dropdown-menu-right">';
    rows += '<a href="#"  class="dropdown-item"  onclick="_View(' + ID +')">';
    rows += ' <i class="fas fa-eye mr-2"></i>View';
    rows += '</a>';
    rows += ' <div class="dropdown-divider"></div>';
    rows += '<a href="#" class="dropdown-item"  onclick="_Edit(' + ID +')">';
    rows += '<i class="fas fa-pencil-alt mr-2"></i>Edit';
    rows += ' </a>';
    rows += ' <div class="dropdown-divider"></div>';
    rows += ' <a href="#" class="dropdown-item"  onclick="_Delete(' + ID +')">';
    rows += '<i class="fas fa-trash mr-2"></i> Delete';
    rows += '</a> ';
    rows += '</div>';
    rows += '</div>';
    rows += '</ul>';

    return rows;
}


var specialKeys = new Array();
specialKeys.push(8); //Backspace
function IsNumeric(e) {
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
    document.getElementById("error").style.display = ret ? "none" : "inline";
    return ret;
}

function printPage(obj,F) {
    var url = '';
    if (F == 1)
        url = '@Url.Action("EmployeePDF", "PrintPDF")';
    if (F == 2)
        url = '@Url.Action("VehiclePDF", "PrintPDF")';
    if (F == 3)
        url = '@Url.Action("CostCenterPDF", "PrintPDF")';
    if (F == 4)
        url = '@Url.Action("SubAccountPDF", "PrintPDF")';
    if (F == 5)
        url = '@Url.Action("SupplierPDF", "PrintPDF")';
    if (F == 6)
        url = '@Url.Action("ExpensesPDF", "PrintPDF")';
    if (F == 7)
        url = '@Url.Action("BankPDF", "PrintPDF")';
    if (F == 8)
        url = '@Url.Action("InsurancePDF", "PrintPDF")';
    var _id = $(obj).attr("_PrintID");
    window.open(url + "?ID=" + _id);
}