function AlertMessage(messagetype, message) {

    $("#AlertMessage").empty();
    var cssclass;
    
    switch (messagetype) {
        case 'Success':
            cssclass = 'alert-success';
            break;
        case 'Error':
            cssclass = 'alert-danger';
            break;
        case 'Warning':
            cssclass = 'alert-warning';
            break;
        default:
            cssclass = 'alert-info';
    }
    $("#AlertMessage").append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a><strong>' + messagetype + ' !</strong><span> ' + message + '</span></div>');
    Alert_fadeto();
};

function Alert_fadeto() {
    $("#alert_div").fadeTo("slow", 10).fadeOut(5000, function () {
        $("#alert_div").remove();
    });
};

function AlertTost(messagetype, message) {
    switch (messagetype) {
        case 'error':
            toastr.error(message);
            break;
        case 'success':
            toastr.success(message);
            break;
        case 'warning':
            toastr.warning(message);
            break;
        case 'info':
            toastr.info(message);
            break;
        default:
        //    toastr.info(message)
    }
}


async function AjaxCall(url, data) {
   
    var Dropdown = JSON.stringify(data);
    var result;
    await $.ajax({
        type: "Post",
        url: url,
        timeout:999999999,
        data: Dropdown,
        dataType: "Text",
        contentType: "application/json;charset=utf-8",
        cache: false,
        async: true,
        beforeSend: function () {
            Swal.fire({
                html: '<div class="loader" id="loader-6">' +
                    '<span></span>' +
                    '<span></span>' +
                    '<span></span>' +
                    '<span></span>' +
                    '</div>' +
                    '<div>' +
                    '<p style="color:#fff; font-size:20px;">PLEASE WAIT...</p>' +
                    '</div>',
                background: 'unset',
                allowOutsideClick: false,
                showConfirmButton: false,
            });
        },
        success: function (responce) {
            if (responce == "-21") {
                window.location.href = "/SessionExpired";
            }
            else if (responce == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                result = responce;
            }
            Swal.close();
 
            function sleep(time) {
                return new Promise((resolve) => setTimeout(resolve, time));
            }
            sleep(500).then(() => {
                $("#loadMe").modal("hide");
            });
        },
        error: function (error) {
            alert("Error:" + error);
           // Swal.close();
            //function sleep(time) {
            //    return new Promise((resolve) => setTimeout(resolve, time));
            //}
            //sleep(500).then(() => {
            //    $("#loadMe").modal("hide");
            //});    
        }
    });
    return result;
};


async function AjaxCallNoReturn(url, data) {
    var Dropdown = JSON.stringify(data);
    var msg;
    await $.ajax({
        type: "Post",
        url: url,
        timeout: 999999999,
        data: Dropdown,
        dataType: "Text",
        cache: false,
        async: true,
        contentType: "application/json;charset=utf-8",
        //beforeSend: function () {
        //    Swal.fire({
        //        html: '<div class="loader" id="loader-6">' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '</div>' +
        //            '<div>' +
        //            '<p style="color:#fff; font-size:20px;">PLEASE WAIT...</p>' +
        //            '</div>',
        //        background: 'unset',
        //        allowOutsideClick: false,
        //        showConfirmButton: false,
        //    });
        //},
        success: function (data) {
            if (data == "504") {
                window.location.href = "/SessionExpired";
            }
            else if (data == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                msg = data;
            }
           // Swal.close();          

            $(".msg").find("p").remove();
            $(".msg").append(msg);
           // Swal.close();
        },
        error: function (error) {
            alert("Error:" + error);
           // Swal.close();
        }
    });
};

 async function AjaxCallWithoutData(url) {
    var result;
     await $.ajax({
        type: "Post",
        url: url,
        dataType: "Text",
        cache: false,
        timeout: 999999999,
        async: true,
        contentType: "application/json;charset=utf-8",
        //beforeSend: function () {
        //    Swal.fire({
        //        html: '<div class="loader" id="loader-6">' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '</div>' +
        //            '<div>' +
        //            '<p style="color:#fff; font-size:20px;">PLEASE WAIT...</p>' +
        //            '</div>',
        //        background: 'unset',
        //        allowOutsideClick: false,
        //        showConfirmButton: false,
        //    });
        //},
        success: function (responce) {
            if (responce == "-21") {
                window.location.href = "/SessionExpired";
            }
            else if (responce == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                result = responce;
            }
           // Swal.close();
        },
        error: function (error) {
            alert("Error:" + error);
           // Swal.close();
        }
    });
    return result;
};



function AjaxCallNoAsync(url, data) {
    var Dropdown = JSON.stringify(data);
    var result;
    $.ajax({
        type: "Post",
        url: url,
        timeout: 999999999,
        data: Dropdown,
        dataType: "Text",
        contentType: "application/json;charset=utf-8",
        cache: false,
        async: false,
        success: function (responce) {
            if (responce == "-21") {
                window.location.href = "/SessionExpired";
            }
            else if (responce == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                result = responce;
            }
           // Swal.close();
        },
        error: function (error) {
            alert("Error:" + error);
           // Swal.close();
        }
    });
    return result;
};

async function AjaxCallNoWait(url, data) {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
    } catch (error) {
        console.error('Error:', error);
    }
}

function AjaxCallNoReturnNoAsync(url, data) {
    var Dropdown = JSON.stringify(data);
    var msg;
    $.ajax({
        type: "Post",
        url: url,
        data: Dropdown,
        dataType: "Text",
        timeout: 999999999,
        cache: false,
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            if (responce == "-21") {
                window.location.href = "/SessionExpired";
            }
            else if (responce == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                msg = data;
            }
           

            $(".msg").find("p").remove();
            $(".msg").append(msg);
        },
        error: function (error) {
            alert("Error:" + error);
        }
    });
};

function AjaxCallWithoutDataNoAsync(url) {
    var result;
    $.ajax({
        type: "Post",
        url: url,
        timeout: 999999999,
        dataType: "Text",
        cache: false,
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (responce) {
            if (responce == "-21") {
                window.location.href = "/SessionExpired";
            }
            else if (responce == "401") {
                window.location.href = "/Dashboard";
            }
            else {
                result = responce;
            }
          
           // Swal.close();
        },
        error: function (error) {
            alert("Error:" + error);
           // Swal.close();
        }
    });
    return result;
};



//function fnExcelParmReport(TableToExport, profile, parameter) {
//    var tab_text = '<table border="0.5px">';
//    var textRange;
//    var j = 0;
//    var lines = TableToExport.rows.length;
//    var columncount = TableToExport.rows[0].cells.length;
//    if (lines > 0) {
//        tab_text = tab_text + "<tr> <td align=left  colspan=" + columncount + " > " + profile + "<br/>" + parameter + "</td></tr>";
//        tab_text = tab_text + '<tr>' + TableToExport.rows[0].innerHTML + '</tr>';
//    }
//    for (j = 1; j < lines; j++) {
//        tab_text = tab_text + "<tr>" + TableToExport.rows[j].innerHTML + "</tr>";
//    }
//    tab_text = tab_text + "</table>";
//    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "")
//    tab_text = tab_text.replace(/<img[^>]*>/gi, "");
//    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, "");
//    var ua = window.navigator.userAgent;
//    var msie = ua.indexOf("MSIE ");
//    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
//        txtArea1.document.open("txt/html", "replace");
//        txtArea1.document.write(tab_text);
//        txtArea1.document.close();
//        txtArea1.focus();
//        sa = txtArea1.document.execCommand("SaveAs", true, "DataTableExport.xls");
//    }
//    else
//        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));
//    return (sa);
//}


function fnExcelParmReport(TableToExport, profile, parameter) {
    var tab_text = '';
    var $table = $(TableToExport);
    var $thead = $table.find('thead');
    var $tbody = $table.find('tbody');
    var $tfoot = $table.find('tfoot');
    var columncount = $thead.find('th').length;
    tab_text += '<table border="0.5px">';
    tab_text += "<tr><td align='left' valign='top' colspan='" + columncount + "'>" + profile + "<br/>" + parameter + "</td></tr>";
    if ($thead.length > 0) {
        $thead.find('tr').each(function () {
            var $row = $(this);
            tab_text += "<tr>";
            $row.find('th').each(function () {
                var $cell = $(this);
                if ($cell.css('display') !== 'none' && !$cell.attr('hidden') && !$cell.hasClass("excelDisable")) {
                    var colspan = $cell.attr('colspan') || 1;
                    var rowspan = $cell.attr('rowspan') || 1;
                    var cellContent = $cell.html().replace(/<p[^>]*>/gi, "").replace(/<\/p>/gi, "<br>");
                    tab_text += "<th colspan='" + colspan + "' rowspan='" + rowspan + "'>" + cellContent + "</th>";
                }
            });
            $row.find('td').each(function () {
                var $cell = $(this);
                if ($cell.css('display') !== 'none' && !$cell.attr('hidden') && !$cell.hasClass("excelDisable")) {
                    var colspan = $cell.attr('colspan') || 1;
                    var rowspan = $cell.attr('rowspan') || 1;
                    var cellContent = $cell.html().replace(/<p[^>]*>/gi, "").replace(/<\/p>/gi, "<br>");
                    tab_text += "<th colspan='" + colspan + "' rowspan='" + rowspan + "'>" + cellContent + "</th>";
                }
            });
            tab_text += "</tr>";
        });
    }
    if ($tbody.length > 0) {
        $tbody.find('tr').each(function () {
            var $row = $(this);
            tab_text += "<tr>";
            $row.find('th, td').each(function () {
                var $cell = $(this);
                if ($cell.css('display') !== 'none' && !$cell.attr('hidden') && !$cell.hasClass("excelDisable")) {
                    var colspan = $cell.attr('colspan') || 1;
                    var rowspan = $cell.attr('rowspan') || 1;
                    var cellContent = $cell.html().replace(/<p[^>]*>/gi, "").replace(/<\/p>/gi, "<br>");
                    if ($cell.is('th')) {
                        tab_text += "<th colspan='" + colspan + "' rowspan='" + rowspan + "' valign='top'>" + cellContent + "</th>";
                    } else {
                        tab_text += "<td colspan='" + colspan + "' rowspan='" + rowspan + "' valign='top'>" + cellContent + "</td>";
                    }
                }
            });
            tab_text += "</tr>";
        });
    }
    if ($tfoot.length > 0) {
        $tfoot.find('tr').each(function () {
            var $footerRow = $(this);
            tab_text += "<tr>";
            $footerRow.find('td').each(function () {
                var $footerCell = $(this);
                if ($footerCell.css('display') !== 'none' && !$footerCell.attr('hidden') && !$cell.hasClass("excelDisable")) {
                    var colspan = $footerCell.attr('colspan') || 1;
                    var rowspan = $footerCell.attr('rowspan') || 1;
                    var cellContent = $footerCell.html().replace(/<p[^>]*>/gi, "").replace(/<\/p>/gi, "<br>");
                    tab_text += "<td colspan='" + colspan + "' rowspan='" + rowspan + "' valign='top'>" + cellContent + "</td>";
                }
            });
            tab_text += "</tr>";
        });
    }

    tab_text += "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "");
    tab_text = tab_text.replace(/<img[^>]*>/gi, ""); 
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, "");
    var blob = new Blob([tab_text], { type: "application/vnd.ms-excel" });
    var url = URL.createObjectURL(blob);
    var a = document.createElement('a');
    a.href = url;
    a.download = 'DataTableExport.xls';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}



function fnExcelReport(TableToExport) {
    var tab_text = '<table border="1px" style="font-size:20px" ">';
    var textRange;
    var j = 0;
    var lines = TableToExport.rows.length;
    if (lines > 0) {
        tab_text = tab_text + '<tr bgcolor="#DFDFDF">' + TableToExport.rows[0].innerHTML + '</tr>';
    }
    for (j = 1; j < lines; j++) {
        tab_text = tab_text + "<tr>" + TableToExport.rows[j].innerHTML + "</tr>";
    }

    tab_text = tab_text + "</table>";
    tab_text = tab_text.replace(/<A[^>]*>|<\/A>/g, "")
    tab_text = tab_text.replace(/<img[^>]*>/gi, "");
    tab_text = tab_text.replace(/<input[^>]*>|<\/input>/gi, "");
    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");
    if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
        txtArea1.document.open("txt/html", "replace");
        txtArea1.document.write(tab_text);
        txtArea1.document.close();
        txtArea1.focus();
        sa = txtArea1.document.execCommand("SaveAs", true, "DataTableExport.xls");
    }
    else
        sa = window.open('data:application/vnd.ms-excel,' + encodeURIComponent(tab_text));
    return (sa);
}


function AlertAnimation() {
    $("#alert_div").fadeTo("fast", 100).slideUp(2000, function () {
        $("#alert_div").css("display", "none")
        $(".Error").css("display", "none");
        $(".Success").css("display", "none");
        $(".Warning").css("display", "none");
        $(".TokenNotFound").css("display", "none");
    });
}


function AjaxAlertMessage(AffectedRows) {
    $(".AlertMessage").empty();
    var MessageHtml = `
<!--Success-->
<div id="Notification" class="messagealert Success1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Success">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Success!</strong> <span>Saved Successfully !!!</span>
	</div>
</div>
<!--Error-->
<div id="Notification" class="messagealert Error1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Error">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Error!</strong> <span>Not Success !!!</span>
	</div>
</div>
<!--Unauthorized-->
<div id="Notification" class="messagealert Warning1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Warning">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Warning!</strong> <span>Sorry You Are Not authorized!!!</span>
	</div>
</div>
<!--Token Not Found-->
<div id="Notification" class="messagealert TokenNotFound" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Error">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Warning!</strong> <span>Token Not Found!!!Please Sign In Again....</span>
	</div>
</div>
`;
    $(".AlertMessage").append(MessageHtml);
    if (AffectedRows == "Success") {
        $(".Success1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "NotSuccess") {
        $(".Error1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "Unauthorized") {
        $(".Warning1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "TokenNotFound") {
        $(".TokenNotFound").css("display", "Block");
        AlertAnimation();
    }
}


function AlertAnimation() {
    $("#alert_div").fadeTo("fast", 100).slideUp(2000, function () {
        $("#alert_div").css("display", "none")
        $(".Error").css("display", "none");
        $(".Success").css("display", "none");
        $(".Warning").css("display", "none");
        $(".TokenNotFound").css("display", "none");
    });
}


function AjaxAlertMessage(AffectedRows) {
    $(".AlertMessage").empty();
    var MessageHtml = `
<!--Success-->
<div id="Notification" class="messagealert Success1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Success">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Success!</strong> <span>Saved Successfully !!!</span>
	</div>
</div>
<!--Error-->
<div id="Notification" class="messagealert Error1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Error">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Error!</strong> <span>Not Success !!!</span>
	</div>
</div>
<!--Unauthorized-->
<div id="Notification" class="messagealert Warning1" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Warning">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Warning!</strong> <span>Sorry You Are Not authorized!!!</span>
	</div>
</div>
<!--Token Not Found-->
<div id="Notification" class="messagealert TokenNotFound" style="display:none">
	<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in Error">
		<a href="#" class="close" data-dismiss="alert" aria-label="close" style="text-decoration: none;">&times;</a>
		<strong>Warning!</strong> <span>Token Not Found!!!Please Sign In Again....</span>
	</div>
</div>
`;
    $(".AlertMessage").append(MessageHtml);
    if (AffectedRows == "Success") {
        $(".Success1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "NotSuccess") {
        $(".Error1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "Unauthorized") {
        $(".Warning1").css("display", "Block");
        AlertAnimation();
    }
    if (AffectedRows == "TokenNotFound") {
        $(".TokenNotFound").css("display", "Block");
        AlertAnimation();
    }
}



function DisableInput() {
    $("body").find("input").attr('disabled', true);
    $("body").find("submit").attr('disabled', true);
    $("body").find("select").attr('disabled', true);
    $("body").find("TxtQuestion").attr('disabled', true);
    $("body").find("button").not(".BtnAdd ").attr('disabled', true);
    $("body").find("textarea").attr('disabled', true);
}

function EnableInput() {

    $("body").find("input").removeAttr('disabled');
    $("body").find("select").removeAttr('disabled');
    $("body").find("textarea").removeAttr('disabled');
    $("body").find("submit").removeAttr('disabled');
    $("body").find("textarea").removeAttr('disabled');
    $("body").find("button").not(".BtnAdd").removeAttr('disabled');
}



async function AjaxCallFileUpload(FileDom, FolderName) {
    var files = FileDom[0].files;
    var formData = new FormData();
    for (var i = 0; i != files.length; i++) {
        formData.append("files", files[i]);
    }
    await $.ajax({
        url: "/Helper/FileUpload?FolderName=" + FolderName + "",
        data: formData,
        processData: false,
        contentType: false,
        timeout: 999999999,
        dataType: "Text",
        type: "POST",
        //beforeSend: function () {
        //    Swal.fire({
        //        html: '<div class="loader" id="loader-6">' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '<span></span>' +
        //            '</div>' +
        //            '<div>' +
        //            '<p style="color:#fff; font-size:20px;">PLEASE WAIT...</p>' +
        //            '</div>',
        //        background: 'unset',
        //        allowOutsideClick: false,
        //        showConfirmButton: false,
        //    });
        //    DisableInput();
        //},
        success: function (data) {
            $(FileDom).attr("data-filename", data);
            $(FileDom).attr('value', data);
            EnableInput();
           // Swal.close();
        },
        error: function () {
            alert("Error:" + error);
            EnableInput();
           // Swal.close();
        }
    });
}






