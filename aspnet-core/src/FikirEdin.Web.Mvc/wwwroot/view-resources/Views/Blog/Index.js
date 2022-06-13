(function ($) {
    var _blogService = abp.services.app.blog,
        l = abp.localization.getSource('FikirEdin'),
        _$modal = $('#BlogCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#blogTable'),
        _fileUpload = _$form.find('#BlogPicture'),
        _fileName = _$form.find('#hfPictureName');

    var _$blogTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _blogService.getAll,
            inputFilter: function () {
                return $('#BlogSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$blogTable.draw(false)
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
                data: 'blogTitle',
                sortable: false
            },
            {
                targets: 2,
                data: 'blogViewCount',
                sortable: false
            },
            {
                targets: 3,
                data: 'blogCategory.categoryName',
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
                        `   <button type="button" class="btn btn-sm bg-secondary edit-blog" data-blog-id="${row.id}" data-toggle="modal" data-target="#BlogEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-blog" data-blog-id="${row.id}" data-blog-name="${row.blogTitle}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });


    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var len = _fileUpload[0].files.length;
        if (len > 0) {
            var formData = new FormData();
            formData.append('file', _fileUpload[0].files[0]);

            abp.ajax({
                url: abp.appPath + 'api/PictureUpload/BlogPicture',
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
       
        var blog = _$form.serializeFormToObject();
        var ckeditorvalues = CKEDITOR.instances['blogDescription'].getData();
        blog.blogDescription = ckeditorvalues;
        _blogService.create(blog).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$blogTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
            CKEDITOR.instances['blogDescription'].setData('');
        });

    }


    $(document).on('click', '.delete-blog', function () {
        var blogId = $(this).attr("data-blog-id");
        var blogTitle = $(this).attr('data-blog-name');

        deleteBlog(blogId, blogTitle);
    });

    function deleteBlog(blogId , blogTitle) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                blogTitle),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _blogService.delete({
                        id: blogId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$blogTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-user', function (e) {
        var userId = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Users/EditModal?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#UserEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    $(document).on('click', 'a[data-target="#BlogCreateModal"]', (e) => {
        $('.nav-tabs a[href="#user-details"]').tab('show')
    });

    abp.event.on('user.edited', (data) => {
        _$usersTable.ajax.reload();
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
