mergeInto(LibraryManager.library, {
    CaptureDownload: function(ptrFileName, ptrJpg, jpgByteLength){
        debugger;
        const fileName = UTF8ToString(ptrFileName);
        const jpgData = HEAPU8.subarray(ptrJpg, ptrJpg + jpgByteLength);
        const blob = new Blob([jpgData],{type:'image/jpeg'});
        let url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.download = fileName;
        a.href = url;
        a.click();
        setTimeout(() => {
            URL.revokeObjectURL(url);
        }, 20);
    }
});