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