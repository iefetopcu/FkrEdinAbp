(function ($) {
    var _blogCategoryService = abp.services.app.blogCategory,
        l = abp.localization.getSource('FikirEdin'),
        _$modal = $('#blogCategoryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#blogCategoryTable');

    var _$blogCategoryTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _blogCategoryService.getAll,
            inputFilter: function () {
                return $('#BlogCategorySearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$blogCategoryTable.draw(false)
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-blogCategory" data-blogCategory-id="${row.id}" data-toggle="modal" data-target="#BlogCategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-blogCategory" data-blogCategory-id="${row.id}" data-blog-categoryName="${row.categoryName}">`,
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
        _blogCategoryService.create(values).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$blogCategoryTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-blogCategory', function () {
        var blogCategoryId = $(this).attr("data-blogCategory-id");
        var blogCategoryName = $(this).attr('data-blog-categoryName');

        deleteBlogCategory(blogCategoryId, blogCategoryName);
    });

    function deleteBlogCategory(blogCategoryId, blogCategoryName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                blogCategoryName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _blogCategoryService.delete({
                        id: blogCategoryId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _blogCategoryService.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-blogCategory', function (e) {
        var id = $(this).attr("data-blogCategory-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Blog/EditModalCategory?id=' + id,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#BlogCategoryEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#BlogCategoryCreateModal"]', (e) => {
        $('.nav-tabs a[href="#blogcategory-details"]').tab('show')
    });

    abp.event.on('blogcategory.edited', (data) => {
        _$blogCategoryTable.ajax.reload();
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
