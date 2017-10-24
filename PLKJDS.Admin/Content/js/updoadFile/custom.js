
$(document).ready(function () {
    var filearr = [];
    var filrstr = "";
    var body = $(document.body),
        filer_default_opts = {
            changeInput2: '<div class="jFiler-input-dragDrop"><div class="jFiler-input-inner"><div class="jFiler-input-icon"><i class="icon-jfi-cloud-up-o"></i></div><div class="jFiler-input-text"><h3>Drag&Drop files here</h3> <span style="display:inline-block; margin: 15px 0">or</span></div><a class="jFiler-input-choose-btn blue-light">Browse Files</a></div></div>',
            limit: null,
            templates: {
                box: '<ul class="jFiler-items-list jFiler-items-grid"></ul>',
                item: '<li class="jFiler-item" style="width: 33%">\
                            <div class="jFiler-item-container">\
                                <div class="jFiler-item-inner">\
                                    <div class="jFiler-item-thumb">\
                                        <div class="jFiler-item-status"></div>\
                                        <div class="jFiler-item-info">\
                                            <span class="jFiler-item-title"><b title="{{fi-name}}">{{fi-name | limitTo: 25}}</b></span>\
                                            <span class="jFiler-item-others">{{fi-size2}}</span>\
                                        </div>\
                                        {{fi-image}}\
                                    </div>\
                                    <div class="jFiler-item-assets jFiler-row" style="width:75%">\
                                        <ul class="list-inline pull-left">\
                                            <li>{{fi-progressBar}}</li>\
                                        </ul>\
                                        <ul class="list-inline pull-right">\
                                            <li><a class="icon-jfi-trash jFiler-item-trash-action"></a></li>\
                                        </ul>\
                                    </div>\
                                </div>\
                            </div>\
                        </li>',
                itemAppend: '<li class="jFiler-item" style="width: 33%">\
                                <div class="jFiler-item-container">\
                                    <div class="jFiler-item-inner">\
                                        <div class="jFiler-item-thumb">\
                                            <div class="jFiler-item-status"></div>\
                                            <div class="jFiler-item-info">\
                                                <span class="jFiler-item-title"><b title="{{fi-name}}">{{fi-name | limitTo: 25}}</b></span>\
                                                <span class="jFiler-item-others">{{fi-size2}}</span>\
                                            </div>\
                                            {{fi-image}}\
                                        </div>\
                                        <div class="jFiler-item-assets jFiler-row" style="width:75%">\
                                            <ul class="list-inline pull-left" style="border-top: 0.5px dashed lightgrey;padding-top:2px;width:88%">\
                                                <li><span class="jFiler-item-others">{{fi-icon}}</span></li>\
                                            </ul>\
                                            <ul class="list-inline pull-right" style="border-top: 0.5px dashed lightgrey;padding-top: 2px;">\
                                                <li><a class="icon-jfi-trash jFiler-item-trash-action"></a></li>\
                                            </ul>\
                                        </div>\
                                    </div>\
                                </div>\
                            </li>',
                progressBar: '<div class="bar"></div>',
                itemAppendToEnd: false,
                removeConfirmation: true,
                _selectors: {
                    list: '.jFiler-items-list',
                    item: '.jFiler-item',
                    progressBar: '.bar',
                    remove: '.jFiler-item-trash-action'
                }
            },
            dragDrop: {},
            uploadFile: {
                url: '/Course/UploadSource',
                type: 'POST',
                enctype: 'multipart/form-data',
                beforeSend: function(){},
                success: function(data, el){
                    var parent = el.find(".jFiler-jProgressBar").parent();
                    el.find(".jFiler-jProgressBar").fadeOut("slow", function(){
                        $("<div class=\"jFiler-item-others text-success\"><i class=\"icon-jfi-check-circle\"></i> Success</div>").hide().appendTo(parent).fadeIn("slow");
                    });
                    var result = $.parseJSON(data);
                  
                    filearr.push(result.data);
                    filestr = filearr.join(',');
                    $('#FileID').attr('value', filestr);
                },
                error: function(el){
                    var parent = el.find(".jFiler-jProgressBar").parent();
                    el.find(".jFiler-jProgressBar").fadeOut("slow", function(){
                        $("<div class=\"jFiler-item-others text-error\"><i class=\"icon-jfi-minus-circle\"></i> Error</div>").hide().appendTo(parent).fadeIn("slow");    
                    });
                },
                statusCode: null,
                onProgress: null,
                onComplete: null
            },
            onRemove: function(itemEl, file, id, listEl, boxEl, newInputEl, inputEl){
                var file = file.name; //alert(file);
                for(var i=0;i<filearr.length;i++)
                {
                    var temp = filearr[i].split('/')[2].substr(17);
                    if(temp==file)
                    {
                        filearr.splice(i, 1);
                        break;
                    }
                }
                filestr = filearr.join(',');
                $('#FileID').attr('value', filestr);
            },
        };
    
    //Run PrettyPrint
    prettyPrint();
    
    //Pre Collapse
    $('.pre-collapse').on("click", function(e){
        var collapse_class = 'collapsed',
            title = ["<i class=\"fa fa-code pull-left\"></i> + Show the source code", "<i class=\"fa fa-code pull-left\"></i> - Hide the source code"],
            $parent = $(this).closest('.pre-box'),
            $pre = $parent.find('pre').first();
        
        if($parent.hasClass(collapse_class)){
            $pre.slideDown("fast", function(){
                $parent.removeClass(collapse_class);
            });
            $(this).html(title[1]);
        }else{
            $pre.slideUp("fast", function(){
                $parent.addClass(collapse_class);
            });
            $(this).html(title[0]);
        }
    });
    
    //Apply jQuery.filer
    $('#demo-fileInput-1').filer({
        limit: null,
        maxSize: null,
        extensions: null,
        changeInput: filer_default_opts.changeInput2,
        showThumbs: true,
        appendTo: '.demo-fileInput-thumbs',
        theme: "dragdropbox",
        templates: {
            box: '<ul class="jFiler-items-list jFiler-items-grid"></ul>',
            item: '<li class="jFiler-item">\
                        <div class="jFiler-item-container">\
                            <div class="jFiler-item-inner">\
                                <div class="jFiler-item-thumb">\
                                    <div class="jFiler-item-status"></div>\
                                    <div class="jFiler-item-info">\
                                        <span class="jFiler-item-title"><b title="{{fi-name}}">{{fi-name | limitTo: 25}}</b></span>\
                                        <span class="jFiler-item-others">{{fi-size2}}</span>\
                                    </div>\
                                    {{fi-image}}\
                                </div>\
                                <div class="jFiler-item-assets jFiler-row" style="width:75%">\
                                    <ul class="list-inline pull-left">\
                                        <li>{{fi-progressBar}}</li>\
                                    </ul>\
                                    <ul class="list-inline pull-right">\
                                        <li><a class="icon-jfi-trash jFiler-item-trash-action"></a></li>\
                                    </ul>\
                                </div>\
                            </div>\
                        </div>\
                    </li>',
            progressBar: '<div class="bar"></div>',
            itemAppendToEnd: false,
            removeConfirmation: false,
            _selectors: {
                list: '.jFiler-items-list',
                item: '.jFiler-item',
                progressBar: '.bar',
                remove: '.jFiler-item-trash-action',
            }
        },
        dragDrop: filer_default_opts.dragDrop,
        uploadFile: filer_default_opts.uploadFile
    });

    $('#demo-fileInput-2').filer();

    $('#demo-fileInput-3').filer({
        limit: 3,
        maxSize: 3,
        extensions: ['jpg', 'jpeg', 'png', 'gif'],
        changeInput: true,
        showThumbs: true
    });

    $('#demo-fileInput-4').filer({
        changeInput: '<div class="jFiler-input-dragDrop"><div class="jFiler-input-inner"><div class="jFiler-input-icon"><i class="icon-jfi-folder"></i></div><div class="jFiler-input-text"><h3>Click on this box</h3> <span style="display:inline-block; margin: 15px 0">or</span></div><a class="jFiler-input-choose-btn blue-light">Browse Files</a></div></div>',
        showThumbs: true,
        theme: "dragdropbox",
        templates: filer_default_opts.templates
    });

    $('#demo-fileInput-5').filer({
        limit: 3,
        maxSize: 3,
        extensions: ['jpg', 'jpeg', 'png', 'gif'],
        showThumbs: true,
        addMore: true
    });

    $('#demo-fileInput-6').filer({
        changeInput: filer_default_opts.changeInput2,
        showThumbs: true,
        theme: "dragdropbox",
        
        templates: filer_default_opts.templates,
        dragDrop: filer_default_opts.dragDrop,
        uploadFile: filer_default_opts.uploadFile,
        onRemove: filer_default_opts.onRemove
    });

    $('#demo-fileInput-7').filer({
        showThumbs: true,
        templates: filer_default_opts.templates,
        uploadFile: filer_default_opts.uploadFile
    });

    $('#demo-fileInput-8').filer({
        showThumbs: true,
        templates: filer_default_opts.templates,
        addMore: true,
        files: [
            {
                name: "appended_file.jpg",
                size: 5453,
                type: "image/jpg",
                file: "http://dummyimage.com/720x480/f9f9f9/191a1a.jpg"
            },
            {
                name: "appended_file_2.jpg",
                size: 9453,
                type: "image/jpg",
                file: "http://dummyimage.com/640x480/f9f9f9/191a1a.jpg"
            }
        ]
    });
});

