(function ($) {
    var _productCategoryService = abp.services.app.category,
        l = abp.localization.getSource('FikirEdin'),
        _$modal = $('#productCategoryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#productCategoryTable');

    var _$productCategoryTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productCategoryService.getAll,
            inputFilter: function () {
                return $('#ProductCategorySearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$productCategoryTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'categoryName',
                sortable: false
            },                             
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-productCategory" data-productCategory-id="${row.id}" data-toggle="modal" data-target="#ProductCategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-productCategory" data-productCategory-id="${row.id}" data-blog-categoryName="${row.categoryName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }
        
        var values = _$form.serializeFormToObject();               

         
        
        abp.ui.setBusy(_$modal);
        _productCategoryService.create(values).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$productCategoryTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-productCategory', function () {
        var productCategoryId = $(this).attr("data-productCategory-id");
        var productCategoryName = $(this).attr('data-blog-categoryName');

        deleteProductCategory(productCategoryId, productCategoryName);
    });

    function deleteProductCategory(productCategoryId, productCategoryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                productCategoryName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _productCategoryService.delete({
                        id: productCategoryId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$productCategoryTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-productCategory', function (e) {
        var id = $(this).attr("data-productCategory-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Product/EditModalCategory?id=' + id,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductCategoryEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#ProductCategoryCreateModal"]', (e) => {
        $('.nav-tabs a[href="#productcategory-details"]').tab('show')
    });

    abp.event.on('productcategory.edited', (data) => {
        _$productCategoryTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$blogTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$blogTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
