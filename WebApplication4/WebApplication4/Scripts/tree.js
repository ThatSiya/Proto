$(function () {
    $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
    $('.tree li.parent_li > span').on('click', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            children.hide('fast');
            $(this).attr('title', 'Expand this branch').find(' > i').addClass('icon-folder-close').removeClass('icon-folder-open');
        } else {
            children.show('fast');
            $(this).attr('title', 'Collapse this branch').find(' > i').addClass('icon-folder-open').removeClass('icon-folder-close');
        }
        e.stopPropagation();
    });

    $('.tree li a').after('      <div class="pull-right btn-group btn-group-sm">\
        <button class="btn btn-info"><i class="icon-edit"></i></button>\
        <button class="btn btn-warning"><i class="icon-trash"></i></button>\
      </div>');
});