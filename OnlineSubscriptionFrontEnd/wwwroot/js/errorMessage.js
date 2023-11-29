function ErrorMessage(message) {

    var value = `
    <!--begin::Alert-->
<div class="position-absolute top-5 alert alert-dismissible bg-danger d-flex flex-column flex-sm-row p-5 mb-10">
  <!--begin::Icon-->
  <i class="ki-duotone ki-search-list fs-2hx text-light me-4 mb-5 mb-sm-0"><span class="path1"></span><span class="path2"></span><span class="path3"></span></i>
  <!--end::Icon-->

  <!--begin::Wrapper-->
  <div class="d-flex flex-column text-light pe-0 pe-sm-10">
      <!--begin::Title-->
      <h4 class="mb-2 light  text-white ">${message}</h4>
      <!--end::Title-->

    
  </div>
  <!--end::Wrapper-->

  <!--begin::Close-->
  <button type="button" class="text-white position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto" data-bs-dismiss="alert">
     X
  </button>
  <!--end::Close-->
</div>
<!--end::Alert-->
    `
    return value;
}