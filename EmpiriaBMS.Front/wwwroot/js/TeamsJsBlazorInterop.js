export function initializeAsync() {
  return microsoftTeams.app.initialize();
}

export function getContextAsync() {
  return microsoftTeams.app.getContext();
}

export function setCurrentFrame(contentUrl, websiteUrl) {
  microsoftTeams.pages.setCurrentFrame(contentUrl, websiteUrl);
}

export function registerFullScreenHandler() {
  return microsoftTeams.pages.registerFullScreenHandler();
}

export function registerChangeConfigHandler() {
  microsoftTeams.pages.config.registerChangeConfigHandler();
}

export function getTabInstances(tabInstanceParameters) {
  return microsoftTeams.pages.tabs.getTabInstances(tabInstanceParameters);
}

export function getMruTabInstances(tabInstanceParameters) {
  return microsoftTeams.pages.tabs.getMruTabInstances(tabInstanceParameters);
}

export function shareDeepLink(deepLinkParameters) {
  microsoftTeams.pages.shareDeepLink(deepLinkParameters);
}

export function openLink(deepLink) {
  return microsoftTeams.app.openLink(deepLink);
}

export function navigateToTab(tabInstance) {
  return microsoftTeams.pages.tabs.navigateToTab(tabInstance);
}

export function initializeTooltips() {
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    })
}

// Settings module
export function registerOnSaveHandler(settings) {
  microsoftTeams.pages.config.registerOnSaveHandler((saveEvent) => {
    microsoftTeams.pages.config.setConfig(settings);
    saveEvent.notifySuccess();
  });

  microsoftTeams.pages.config.setValidityState(true);
}

// Come from here: https://github.com/wictorwilen/msteams-react-base-component/blob/master/src/useTeams.ts
export function inTeams() {
  if (
    (window.parent === window.self && window.nativeInterface) ||
    window.navigator.userAgent.includes("Teams/") ||
    window.name === "embedded-page-container" ||
    window.name === "extension-tab-frame"
  ) {
    return true;
  }
  return false;
}

export function getScreenSize() {
    return {
        width: window.innerWidth,
        height: window.innerHeight
    };
};

export function navigateToAdmin(url, objectId) {
    fetch(url, {
        method: 'GET',
        headers: {
            'ObjectId': objectId
        }
    }).then(response => {
        if (response.ok) {
            window.location.href = response.url; // Redirect to the returned URL
        } else {
            console.error('Failed to navigate:', response.status);
        }
    }).catch(error => {
        console.error('Error navigating:', error);
    });
}

export function saveAsFile(fileName, byteBase64, contentType) {
    const linkSource = `data:${contentType};base64,${byteBase64}`;
    const downloadLink = document.createElement('a');
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
};

export function getAspectRatio() {
    var width = window.innerWidth;
    var height = window.innerHeight;
    return width / height;
}

export function scrollToElement(id) {
    var element = document.getElementById(id);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
}


// Dragable Compoments
export function initializeDragAndDrop(divId) {
    var containers = document.querySelector('.dashboard-grid');
    if (containers) {
        dragula([containers]).on('drag', function (el) {
            console.log('Element is being dragged:', el);
        });
    } else {
        console.error("Dashboard grid container not found.");
    }
};
// Dragable Compoments


// Register MNouse Weel Event
export function registerGlobalMouseWheelEvent(objRef, id) {
    $('[data-id="' + id + '"]').on('wheel', function (e) {
        var deltaY = e.originalEvent.deltaY;
        var focusedElement = $(':focus');
        if (focusedElement.is('[data-id="' + id + '"]')) {
            var inputType = focusedElement.data("input-type");
            var inputId = focusedElement.data("id");

            //var currentValue = parseInt(focusedElement.val());
            //var max = parseInt(focusedElement.attr("max"));
            //var min = parseInt(focusedElement.attr("min"));

            //console.log("currentValue: ", currentValue);
            //console.log("max: ", max);
            //console.log("min: ", min);
            //if (currentValue > max) {
            //    focusedElement.val(max);
            //    console.log("currentValue > max");
            //}
            //else if (currentValue < min) {
            //    focusedElement.val(min);
            //    console.log("currentValue < min");
            //}

            if (id == inputId) {
                if (inputType === "hours") {
                    objRef.invokeMethodAsync('OnMouseWheel', deltaY, "hours");
                    //DotNet.invokeMethodAsync('EmpiriaBMS.Front', 'OnMouseWheel', deltaY, "hours");
                } else if (inputType === "minutes") {
                    objRef.invokeMethodAsync('OnMouseWheel', deltaY, "minutes");
                    //DotNet.invokeMethodAsync('EmpiriaBMS.Front', 'OnMouseWheel', deltaY, "minutes");
                }
            }
        }
    });
}
// Register MNouse Weel Event


// Cookies
export function setCookie(key, value) {
    localStorage.setItem(key, value);
}

export function getCookie(key) {
    return localStorage.getItem(key);
}
// Cookies


// Canvas
var signaturePad;

export function initializeCanvas(canvas) {
    fitToContainer(canvas);
    signaturePad = new SignaturePad(canvas);
}

function fitToContainer(canvas) {
    // Make it visually fill the positioned parent
    canvas.style.width = '100%';
    canvas.style.height = '100%';
    // ...then set the internal size to match
    canvas.width = canvas.offsetWidth;
    canvas.height = canvas.offsetHeight;
}

export function clearCanvas(canvas) {
    var context = canvas.getContext('2d');
    context.clearRect(0, 0, canvas.width, canvas.height);
}

export function getCanvasImageData(canvas) {
    var imgData = canvas.toDataURL(); // Get image data as base64 URL
    var base64 = imgData.replace(/^data:image\/(png|jpeg);base64,/, ""); // Remove header
    var byteCharacters = atob(base64); // Decode base64 to byte characters
    var byteNumbers = new Array(byteCharacters.length);

    // Convert byte characters to byte numbers
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }

    // Create byte array
    var byteArray = new Uint8Array(byteNumbers);
    return byteArray;
}
// Canvas



// Google Maps Api
export function displayAddress(mapElementId, address) {
    var map = new google.maps.Map(document.getElementById(mapElementId), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 12
    });
    var geocoder = new google.maps.Geocoder();

    address.forEach(function (add) {
        geocoder.geocode({ 'address': add }, function (results, status) {
            if (status === 'OK') {
                map.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
                console.log('Geocode was successful location: ' + results[0].geometry.location);
            } else {
                console.log('Geocode was not successful for the following reason: ' + status);
            }
        }, error => console.log('Geocode error: ' + error));
    });
}

// Navigate
export function openDirectionsInNewWindow(directionsUrl) {
    window.open(directionsUrl, '_blank');
};

// Autocomplete
export function initializeAutocomplete(inputElementId) {
    const input = document.getElementById(inputElementId);
    const autocomplete = new google.maps.places.Autocomplete(input);
    autocomplete.addListener('place_changed', () => {
        const place = autocomplete.getPlace();
        if (!place.geometry) {
            // Place details not found for the input.
            return;
        }
        // Handle place details (if needed)
    });
};
// Google Maps Api



// Download Document
export function downloadFile(fileName, contentType, base64Content) {
    const byteArray = Uint8Array.from(atob(base64Content), c => c.charCodeAt(0));
    const blob = new Blob([byteArray], { type: contentType });
    const url = URL.createObjectURL(blob);

    const a = document.createElement('a');
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();

    document.body.removeChild(a);
    URL.revokeObjectURL(url);
};
// Download Document


// Pick Folder/File Path
export async function pickFolderPath() {
    try {
        // Create an input element
        const input = document.createElement('input');
        input.type = 'file';
        input.webkitdirectory = true; // Allows directory selection
        input.multiple = false; // Allow only one directory selection

        return new Promise((resolve, reject) => {
            input.onchange = (event) => {
                const file = event.target.files[0];
                if (file) {
                    resolve(file.webkitRelativePath); // Resolve with the directory path
                } else {
                    reject(new Error('No directory selected'));
                }
            };

            // Simulate a click to open the directory picker dialog
            input.click();
        });
    } catch (err) {
        console.error(err);
        return null;
    }
}

export function pickCSVFilePath() {
    try {
        // Create an input element
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = '.csv';

        return new Promise((resolve, reject) => {
            input.onchange = (event) => {
                const file = event.target.files[0];
                if (file) {
                    resolve(file.name);
                } else {
                    reject(new Error('No file selected'));
                }
            };
            input.click();
        });
    } catch (err) {
        console.error(err);
        throw err;
    }
}

export async function pickBakFilePath() {
    try {
        // Create an empty .Bak Blob (assuming .Bak is a custom extension)
        const emptyBakBlob = new Blob([""], { type: 'application/octet-stream' });

        // Create an input element
        const input = document.createElement('input');
        input.type = 'file';
        input.accept = '.Bak'; // Accept only .Bak files

        // Preselect the empty .Bak file
        const dataTransfer = new DataTransfer();
        dataTransfer.items.add(new File([emptyBakBlob], "output.Bak", { type: 'application/octet-stream' }));
        input.files = dataTransfer.files;

        return new Promise((resolve, reject) => {
            input.onchange = (event) => {
                const file = event.target.files[0];
                if (file) {
                    resolve(file.name); // Resolve with the file name
                } else {
                    reject(new Error('No file selected'));
                }
            };

            // Simulate a click to open the file picker dialog
            input.click();
        });
    } catch (err) {
        console.error(err);
        return null;
    }
}
// - Pick Folder/File Path

// Download CSV
export function downloadCsvFile(filename, content) {
    var blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
    var link = document.createElement("a");
    if (link.download !== undefined) {
        var url = URL.createObjectURL(blob);
        link.setAttribute("href", url);
        link.setAttribute("download", filename);
        link.style.visibility = 'hidden';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

export function downloadZipFile(filename, base64Content) {
    // Convert base64 string to binary data
    const byteCharacters = atob(base64Content);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);

    // Create a Blob from the binary data
    const blob = new Blob([byteArray], { type: 'application/zip' });

    // Create an anchor element and trigger a download
    const link = document.createElement("a");
    if (link.download !== undefined) {
        const url = URL.createObjectURL(blob);
        link.setAttribute("href", url);
        link.setAttribute("download", filename);
        link.style.visibility = 'hidden';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

export function downloadBakFile(filename, content) {
    var blob = new Blob([content], { type: 'application/octet-stream' }); // Adjust MIME type if needed
    var link = document.createElement("a");
    if (link.download !== undefined) {
        var url = URL.createObjectURL(blob);
        link.setAttribute("href", url);
        link.setAttribute("download", filename + ".Bak"); // Add .Bak extension
        link.style.visibility = 'hidden';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

// - Download CSV


// Element Click
export function triggerFileInputClick(element) {
    element.click();
};
// - Element Click

// PDF
export async function exportPdfContent(elementIds, fileName) {
    try {
        const { jsPDF } = window.jspdf;
        const doc = new jsPDF({
            orientation: 'landscape',
            unit: 'mm',
            format: 'a4'
        });

        const padding = 20;

        for (let i = 0; i < elementIds.length; i += 2) {
            // Add a new page for every pair of elements
            if (i > 0) {
                doc.addPage();
            }

            for (let j = 0; j < 2; j++) {
                const elementId = elementIds[i + j];
                if (elementId) {
                    const elementHTML = document.getElementById(elementId);
                    if (elementHTML) {
                        // Use html2canvas to capture the element
                        const canvas = await html2canvas(elementHTML, { scale: 1 });
                        const imgData = canvas.toDataURL('image/png');

                        // Calculate the width and height of the PDF page
                        const pdfWidth = doc.internal.pageSize.getWidth() - 2 * padding;
                        const pdfHeight = (canvas.height * pdfWidth) / canvas.width;

                        // Position the first element at the top and the second element below it
                        const yOffset = padding + j * (pdfHeight + 2 * padding);

                        // Add the image to the PDF
                        doc.addImage(imgData, 'PNG', padding, yOffset, pdfWidth, pdfHeight);
                    } else {
                        console.warn(`Element with ID ${elementId} not found.`);
                    }
                }
            }
        }

        doc.save(fileName);
    } catch (error) {
        console.error('Error exporting elements to PDF:', error);
    }
}
// - PDF