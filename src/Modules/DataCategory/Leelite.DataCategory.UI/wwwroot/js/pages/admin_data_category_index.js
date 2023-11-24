/* ------------------------------------------------------------------------------
        *
        *  # Page header
        *
        *  Demo JS code for content_page_header.html page
        *
        * ---------------------------------------------------------------------------- */


// Setup module
// ------------------------------

const PageHeader = function () {

    //
    // Setup module components
    //

    // Bootstrap multiselect
    const _componentMultiselect = function () {
        if (!$().multiselect) {
            console.warn('Warning - bootstrap_multiselect.js is not loaded.');
            return;
        }

        // Initialize
        $('.form-control-multiselect').multiselect();
    };

    // Uniform
    var _componentFancytree = function () {
        if (!$().fancytree) {
            console.warn('Warning - fancytree_all.min.js is not loaded.');
            return;
        }


        // Basic setup
        // ------------------------------

        // Basic example
        $('.tree-default').fancytree({
            init: function (event, data) {
                $('.has-tooltip .fancytree-title').tooltip();
            }
        });
    };

    //
    // Return objects assigned to module
    //

    return {
        initComponents: function () {
            _componentMultiselect();
            _componentFancytree();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function () {
    PageHeader.initComponents();
});

function toIndex(id) {
    window.location.href = '/Admin/DataCategory?categoryTypeId=' + id;
}

function toCategoryTypeCreate() {
    window.location.href = '/Admin/DataCategory/CategoryTypeCreate';
}

function toCategoryTypeEdit(id) {
    event.stopPropagation();

    window.location.href = '/Admin/DataCategory/CategoryTypeEdit/' + id;
}

function toCategoryCreate(categoryTypeId) {
    var parentId = 0;

    const tree = $.ui.fancytree.getTree('.tree-default');

    var activeNode = tree.getActiveNode();

    if (activeNode) {
        parentId = activeNode.key;
    }

    window.location.href = '/Admin/DataCategory/CategoryCreate?categoryTypeId=' + categoryTypeId + '&parentId=' + parentId;
}

function toCategoryEdit() {
    var id = 0;

    const tree = $.ui.fancytree.getTree('.tree-default');

    var activeNode = tree.getActiveNode();

    if (activeNode) {
        id = activeNode.key;
    }

    window.location.href = '/Admin/DataCategory/CategoryEdit/' + id;
}

// 删除分类
function deleteCategory() {
    var id = 0;

    const tree = $.ui.fancytree.getTree('.tree-default');

    var activeNode = tree.getActiveNode();

    if (activeNode) {
        id = activeNode.key;
    }

    $.ajax({
        url: '/Admin/DataCategory/CategoryDelete/' + id,
        type: 'POST',
        data: {},
        success: function (data) {
            if (data.success) {
                window.location.reload();
            }
            else {
                alert(data.message);
            }
        }
    });
}