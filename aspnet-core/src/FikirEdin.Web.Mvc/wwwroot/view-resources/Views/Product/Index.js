(function ($) {
    var _productService = abp.services.app.product,
        l = abp.localization.getSource('FikirEdin'),
        _$modal = $('#ProductCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#productTable'),
        _fileUpload = _$form.find('#ProductPicture'),
        _fileName = _$form.find('#hfPictureName');
        
   
    var _$productTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _productService.getAll,
            inputFilter: function () {
                return $('#ProductSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$productTable.draw(false)
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
                data: 'productName',
                sortable: false
            },
            {
                targets: 2,
                data: 'productViewCount',
                sortable: false
            },  
            {
                targets: 3,
                data: 'category.categoryName', "autowith": true,
                sortable: false
            },
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <a href="Product/ProductAddLink/${row.id}" type="button" class="btn btn-sm bg-primary add-link-product">`,
                        `       <i class="fa fa-link"></i> ${l('Link')}`,
                        '   </a>',
                        `   <a href="Product/ProductAddModel/${row.id}" type="button" class="btn btn-sm bg-success add-model-product">`,
                        `       <i class="fa fa-plus"></i> ${l('Model')}`,
                        '   </a>' , 
                    ].join('');
                }
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-product" data-product-id="${row.id}" data-toggle="modal" data-target="#ProductEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-product" data-product-id="${row.id}" data-product-name="${row.productName}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
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

        var len = _fileUpload[0].files.length;
        if (len > 0) {
            var formData = new FormData();
            formData.append('file', _fileUpload[0].files[0]);

            abp.ajax({
                url: abp.appPath + 'api/PictureUpload/ProductPicture',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (content) {
                    _fileName.val(content.fileName);

                    saveFunc();
                },
                error: function (e) {
                    abp.notify.error(e);
                },
                complete: function () {
                    location.reload();
                }
            });
            return;
        }
        saveFunc();
    });

    function saveFunc() {
        abp.ui.setBusy(_$modal);

        var product = _$form.serializeFormToObject();
        var ckeditorvalues = CKEDITOR.instances['productDescription'].getData();
        product.productDescription = ckeditorvalues;
        abp.ui.setBusy(_$modal);
        _productService.create(product).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$productTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
            CKEDITOR.instances['productDescription'].setData('');
        });

    }

    $(document).on('click', '.delete-product', function () {
        var productId = $(this).attr("data-product-id");
        var productName = $(this).attr('data-product-name');

        deleteProduct(productId, productName);
    });

    function deleteProduct(productId, productName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                productName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _productService.delete({
                        id: productId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$productTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-product', function (e) {
        var productId = $(this).attr("data-product-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Product/EditModal?productId=' + productId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#ProductEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#ProductCreateModal"]', (e) => {
        $('.nav-tabs a[href="#product-details"]').tab('show')
    });

    abp.event.on('product.edited', (data) => {
        _$productTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$productTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$productTable.ajax.reload();
            return false;
        }
    });
    
})(jQuery);

