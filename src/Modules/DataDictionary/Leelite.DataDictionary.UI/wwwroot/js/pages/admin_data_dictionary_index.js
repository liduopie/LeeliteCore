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
    
    //
    // Return objects assigned to module
    //

    return {
        initComponents: function () {
            _componentMultiselect();
        }
    }
}();


// Initialize module
// ------------------------------

document.addEventListener('DOMContentLoaded', function () {
    PageHeader.initComponents();
});