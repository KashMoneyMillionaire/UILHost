// At a minimum, options must specify the URL and columns
//
// EX:
//
    //options = {
    //    columns: [
    //           { field: "SetBackLeftUE", hidden: true, title: "Set Back Left UE" },
    //           { field: "CommunityName", title: "Community" },
    //           { field: "Name", title: "Phase" },
    //           { field: "IsContract", title: "Is Contract", hidden: true },
    //           { field: "IsNewDealSummary", title: "Is Executed NDS", hidden: true },
    //           ...
    //    },
    //    url = "http://url.to.service/action"
//}

// Fields can be set to specify model data types for filtering (OPTIONAL)
//
// EX:
//
    //options = {
    //    columns: ...
    //    url: ...
    //    fields: {
    //        CommunityName: { type: "string" },
    //        Name: { type: "string" },
    //        Developer: { type: "string" },
    //        ProjectNumber: { type: "string" },
    //        BrixSection: { type: "string" }
    //    }
//}

// FULL EXAMPLE

    //<div id="grid"></div>

    //<script>

    //    $("#grid").pavlosGrid({
    //        columns: {
            
    //        },
    //        url: "<SERVICE URL>"
    //    });

//</script>

(function (pavlos, $, undefined) { // this block of code defines the root namespace, 'pavlos'

    pavlos.grids = pavlos.grids || {};



    pavlos.grids.addSortArrows = function addSortArrows() {
        var $LinkedTableHeads = $("th.k-header a.k-link");
        $LinkedTableHeads.each(function () {
            if ($(this).children("span").length > 0) {
                return;
            }
            else {
                $(this).append('<span class="fa fa-sort"></span>');
            };
        });
    }

}(window.pavlos = window.pavlos || {}, jQuery));


$.fn.pavlosGrid = function (options) {

    var settings = {
        sortable: {
            mode: "single",
            allowUnsort: false
        },
        selectable: false,
        groupable: false,
        pageable: true,
        filterable: false,
        reorderable: false,
        resizable: true,
        dataBound: pavlos.grids.addSortArrows,
        columnMenu: false,
        scrollable: false,
        columns: [],
        minheight: 500,
        dataSource: {
            transport:
            {
                read:
                {
                    url: null,
                    type: "POST",
                    contentType: "application/json",
                    dataType: "json"
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                fields: []
            },
            requestStart: null,
            pageSize: 25,
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            navigatable: true
        },
        parameterMapReadHandler: null
    };

    if (options) { $.extend(true,settings, options); }

    if (settings.url) { settings.dataSource.transport.read.url = settings.url; }
    if (settings.serviceMethod) { settings.dataSource.transport.read.type = settings.serviceMethod; }
    if (settings.fields) { settings.dataSource.schema.fields = settings.fields; }
    if (settings.defaultFilter) { settings.dataSource.filter = settings.defaultFilter; }

    //if (settings.dataSource.pageSize) { settings.dataSource.pageSize = settings.pageSize; }

    if (settings.dataSource.transport && settings.dataSource.transport.read.type == "POST")
    {
        settings.dataSource.transport.parameterMap = function (opt, operation) {
            if (operation === "read") {
                if (settings.parameterMapReadHandler) { return settings.parameterMapReadHandler(opt); }
                else { return kendo.stringify(opt); }
            }

            // if the current operation is an update
            if (operation === "update") {
                //// create a new JavaScript date object based on the current
                //// BirthDate parameter value
                //var d = new Date(options.BirthDate);
                //// overwrite the BirthDate value with a formatted value that WebAPI
                //// will be able to convert
                //options.BirthDate = kendo.toString(new Date(d), "MM/dd/yyyy");
            }
            // ALWAYS return options
            return opt;
        }
    }

    $(this).kendoGrid({
        columns: settings.columns,
        dataSource: new kendo.data.DataSource({
            transport: settings.dataSource.transport,
            schema: settings.dataSource.schema,
            requestStart: settings.dataSource.requestStart,
            pageSize: settings.dataSource.pageSize,
            serverPaging: settings.dataSource.serverPaging,
            serverSorting: settings.dataSource.serverSorting,
            serverFiltering: settings.dataSource.serverFiltering,
            navigatable: settings.dataSource.navigatable,
            filter: settings.dataSource.filter,
            sort: settings.dataSource.sort
        }),
        sortable: settings.sortable,
        selectable: settings.selectable,
        groupable: settings.groupable,
        pageable: settings.pageable,
        filterable: settings.filterable,
        reorderable: settings.reorderable,
        resizable: settings.resizable,
        columnMenu: settings.columnMenu,
        scrollable: settings.scrollable,
        change: settings.change,
        dataBound: settings.dataBound,
        dataBinding: settings.dataBinding
        //minheight: settings.minheight
    });
}
