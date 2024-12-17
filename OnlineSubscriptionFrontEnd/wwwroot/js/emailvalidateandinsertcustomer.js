<script>
    $(document).ready(function () {
        $("#BtnInsert").on("click", async function (event) {
            debugger
            event.preventDefault();

   @: const emailInput = $('#email').val();
  @: const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    function validateField(selector, message) {
                if ($(selector).val().trim() === "") {
        toastr.warning(message);
    return false;
                }
    return true;
            }

    if (!validateField("#CustName", "Please fill in the Company Name!!!")) return;
    if (!validateField("#CustAddress", "Please fill in the Company Address!!!")) return;
    if (!validateField("#panvat", "Please fill in the PAN / VAT Number!!!")) return;
    if (!validateField("#Custcontact", "Please fill in the Contact Number!!!")) return;
    if (!validateField("#CP1", "Please fill in the Contact Person 1 Name!!!")) return;
    if (!validateField("#CP1Mobno", "Please fill in the Contact Person 1 Contact Number!!!")) return;
    if (!validateField("#CP2", "Please fill in the Contact Person 2 Name!!!")) return;
    if (!validateField("#CP2Mobno", "Please fill in the Contact Person 2 Contact Number!!!")) return;

    if (!validateField("#email", "Please fill in the email Address!!!")) return;
    if (!@:emailRegex.test(emailInput)) {
        toastr.error("Enter a valid email address.");
    return;
            }

    if (!validateField("#website", "Please fill in the website!!!")) return;
    if (!validateField("#CompanyCode", "Please fill in the Company Code!!!")) return;
    if (!validateField("#BySMSApiToken", "Please fill in the SMS API Token!!!")) return;
    if (!validateField("#CountrySelect", "Please choose a country where you live!!!")) return;

    // Prepare data
    var parm = {
        Id: $("#id").val() ? parseInt($("#id").val()) : 0,
    CustomerCode: '',
    CustomerName: $("#CustName").val(),
    Address: $("#CustAddress").val(),
    panvatno: $("#panvat").val(),
    Contact: $("#Custcontact").val(),
    DataBaseLink: '',
    ContactPerson1: $("#CP1").val(),
    ContactPerson2: $("#CP2").val(),
    ContactPerson1_MobileNo: $("#CP1Mobno").val(),
    ContactPerson2_MobileNo: $("#CP2Mobno").val(),
    EmailAddress: $("#email").val(),
    Website: $("#website").val(),
    GUID: '',
    CompanyCode: $("#CompanyCode").val(),
    BySMSApiToken: $("#BySMSApiToken").val(),
    country: $("#CountrySelect").val()
            };

    try {
                var data = await AjaxCall("/Customer/InsertUpdateCustomer", parm);
    var jsondataresponse = JSON.parse(data);

                if (jsondataresponse > 0) {
        resetForm();
    getTableData();
    $("#toggleArrow").trigger('click');
    toastr.success("Customer Action successful!");
    $("#editOrgModal").modal('hide');
                } else {
        toastr.error("Failed to insert/update Customer.");
                }
            } catch (error) {
        toastr.error("An error occurred while saving the customer.");
    console.error(error);
            }
        });
    });
</script>
