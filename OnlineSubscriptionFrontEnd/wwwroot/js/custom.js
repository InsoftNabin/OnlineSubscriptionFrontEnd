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
        timeout: 999999999,
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
           
        },
        error: function (error) {
            alert("Error:" + error);
           
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



// this is for xls format
function fnExcelParmReport(TableToExport, profile, parameter, woksheetname) {

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
                if ($footerCell.css('display') !== 'none' && !$footerCell.attr('hidden') && !$footerCell.hasClass("excelDisable")) {
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
    if (woksheetname == null || woksheetname == undefined || woksheetname == '') {
        a.download = `datatableExport.xls`;

    } else {
        a.download = `${woksheetname}.xls`;
    }
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}
// This is for xlsx
//This requires plugin
//<script src="https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.18.5/xlsx.full.min.js"></script>
function fnExcelParmReportXlsx(TableToExport, profile, parameter, woksheetname) {
    var $table = $(TableToExport);
    var workbook = XLSX.utils.book_new();
    var worksheet = XLSX.utils.aoa_to_sheet([]);

    XLSX.utils.sheet_add_aoa(worksheet, [[profile]], { origin: "A1" });
    XLSX.utils.sheet_add_aoa(worksheet, [[parameter]], { origin: "A2" });

    // Merge cells from A1 to AJ1 for the profile
    worksheet['!merges'] = worksheet['!merges'] || [];
    worksheet['!merges'].push({ s: { r: 0, c: 0 }, e: { r: 0, c: 35 } });
    worksheet['!merges'].push({ s: { r: 1, c: 0 }, e: { r: 1, c: 35 } });
    var data = [];
    var spanMap = {};
    var columnCounts = {};
    $table.find('tr').each(function (rowIndex) {
        var row = [];
        $(this).find('th, td').each(function () {
            var $cell = $(this);
            if ($cell.css('display') !== 'none' && !$cell.attr('hidden') && !$cell.hasClass("excelDisable")) {
                var colspan = parseInt($cell.attr('colspan')) || 1;
                var rowspan = parseInt($cell.attr('rowspan')) || 1;
                var cellContent = $cell.text().trim();
                // Find the next available index for this row
                var colIndex = row.length;
                while (spanMap[`${rowIndex}:${colIndex}`]) {
                    row.push("");
                    colIndex++;
                }
                row.push(cellContent);

                // Apply bold style if it's a <th> element
                if ($cell.is('th')) {
                    var cellRef = XLSX.utils.encode_cell({ r: rowIndex + 2, c: colIndex });

                    // Ensure the cell exists before applying the style
                    if (!worksheet[cellRef]) {
                        worksheet[cellRef] = {}; // Initialize the cell if it doesn't exist
                    }

                    worksheet[cellRef].s = {
                        font: { bold: true }
                    };
                }

                // Mark spanMap for rowspan and colspan
                for (var i = 0; i < rowspan; i++) {
                    for (var j = 0; j < colspan; j++) {
                        if (!(i === 0 && j === 0)) {
                            spanMap[`${rowIndex + i}:${colIndex + j}`] = true;
                        }
                    }
                }

                // Add empty cells for colspan
                for (var i = 1; i < colspan; i++) {
                    row.push("");
                }
            }
        });

        if (row.length > 0) {
            data.push(row);
        }
    });
    XLSX.utils.sheet_add_aoa(worksheet, data, { origin: "A3" });
    // Auto-adjust column widths based on content
    var colWidths = data.reduce((widths, row) => {
        row.forEach((cell, index) => {
            var width = cell ? cell.length : 10;
            widths[index] = Math.max(widths[index] || 0, width);
        });
        return widths;
    }, []);
    worksheet['!cols'] = colWidths.map(width => ({ wch: width + 2 }));

    // Append the worksheet to the workbook
    XLSX.utils.book_append_sheet(workbook, worksheet, "Sheet1");

    // Generate Blob and download the file
    var wbout = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
    var blob = new Blob([wbout], { type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" });
    var url = URL.createObjectURL(blob);
    var a = document.createElement('a');
    a.href = url;
    if (woksheetname == null || woksheetname == undefined || woksheetname == '') {
        a.download = `datatableExport.xlsx`;

    } else {
        a.download = `${woksheetname}.xlsx`;
    }
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}

/////////////////////////////
//print csv  report 
function fnCsvParmReport(TableToExport, profile, parameter, filename) {
    var $table = $(TableToExport);
    var csvData = [];
    var colCount = $table.find('thead tr').first().find('th').length;
       colCount = colCount && colCount > 0 ? colCount : 10; //  for the case of collcount  nullable to make errorfree

    // Create a profile row with default empty columns up to colCount
    let profilerow = [profile].concat(new Array(colCount - 1).fill(''));
    csvData.push(profilerow);

    // Add Parameter Row
    let parameterrow = [parameter].concat(new Array(colCount - 1).fill(''));
    csvData.push(parameterrow);

    // Extract Headers
    function extractHeaders() {
        let headerRows = [];
        let colTracker = [];
        $table.find('thead tr').each(function () {
            let row = [];
            let colIndex = 0;
            $(this).find('th, td').each(function () {
                let $cell = $(this);

                if ($cell.css('display') === 'none' || $cell.attr('hidden') || $cell.hasClass("excelDisable")) {
                    return;
                }

                let cellContent = $cell.text().trim();
                let colspan = parseInt($cell.attr('colspan') || 1, 10);
                let rowspan = parseInt($cell.attr('rowspan') || 1, 10);

                while (colTracker[colIndex] > 0) {
                    row.push('');
                    colTracker[colIndex]--;
                    colIndex++;
                }

                row.push(cellContent);

                for (let i = 1; i < colspan; i++) {
                    row.push('');
                }

                if (rowspan > 1) {
                    for (let i = 0; i < colspan; i++) {
                        colTracker[colIndex + i] = rowspan - 1;
                    }
                }

                colIndex += colspan;
            });

            headerRows.push(row);
        });

        let maxColumns = Math.max(...headerRows.map(row => row.length));
        headerRows.forEach(row => {
            while (row.length < maxColumns) {
                row.push('');
            }
        });

        return headerRows;
    }
    // Extract Body Rows
    function extractBodyRows() {
        let bodyRows = [];
        $table.find('tbody tr').each(function () {
            let row = [];
            let colIndex = 0;
            let colTracker = [];

            $(this).find('td').each(function () {
                let $cell = $(this);

                if ($cell.css('display') === 'none' || $cell.attr('hidden') || $cell.hasClass("excelDisable")) {
                    return;
                }

                let cellContent = $cell.text().trim();
                let colspan = parseInt($cell.attr('colspan') || 1, 10);

                while (colTracker[colIndex] > 0) {
                    row.push('');
                    colTracker[colIndex]--;
                    colIndex++;
                }

                row.push(cellContent);

                for (let i = 1; i < colspan; i++) {
                    row.push('');
                }

                colIndex += colspan;
            });

            if (row.length > 0) {
                bodyRows.push(row);
            }
        });

        let maxColumns = Math.max(...bodyRows.map(row => row.length));
        bodyRows.forEach(row => {
            while (row.length < maxColumns) {
                row.push('');
            }
        });
        return bodyRows;
    }
    // Process Headers and Body Rows
    let headers = extractHeaders();
    headers.forEach(row => csvData.push(row));

    let bodyRows = extractBodyRows();
    bodyRows.forEach(row => csvData.push(row));

    // Convert to CSV Format
    let csvString = csvData.map(row =>
        row.map(cell => `"${cell.replace(/"/g, '""')}"`).join(',')
    ).join('\n');

    // Create Blob and Download
    let blob = new Blob([csvString], { type: 'text/csv;charset=utf-8;' });
    let url = URL.createObjectURL(blob);
    let a = document.createElement('a');
    a.href = url;
    a.download = filename && filename.trim() !== '' ? `${filename}.csv` : 'datatableExport.csv';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}





// Here Ends

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






