$(document).ready(function () {
    $('#example').DataTable({
        dom: 'Bfrtip',
        buttons: [{
            extend: 'pdf',
            title: 'Customized PDF Title',
            filename: 'customized_pdf_file_name'
        }, {
            extend: 'excel',
            title: 'Customized EXCEL Title',
            filename: 'customized_excel_file_name'
        }, {
            extend: 'csv',
            filename: 'customized_csv_file_name'
        }]
    });
});