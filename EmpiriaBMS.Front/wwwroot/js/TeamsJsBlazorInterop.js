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

export function getElementStyle(elementId) {
    const element = document.getElementById(elementId);
    return element ? element.getAttribute("style") : "";
};

export function setElementStyle(elementId, style) {
    const element = document.getElementById(elementId);
    if (element) {
        element.setAttribute("style", style);
    }
};

export function cloneElementContent(sourceId, targetId) {
    const sourceElement = document.getElementById(sourceId);
    const targetElement = document.getElementById(targetId);
    if (sourceElement && targetElement) {
        targetElement.innerHTML = sourceElement.innerHTML;
    }
};

export function clearElementContent(elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.innerHTML = "";
    }
};


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
        const pageHeight = doc.internal.pageSize.getHeight();
        let currentY = padding;

        for (let i = 0; i < elementIds.length; i++) {
            const elementId = elementIds[i];
            if (elementId) {
                const elementHTML = document.getElementById(elementId);
                if (elementHTML) {
                    // Use html2canvas to capture the element
                    const canvas = await html2canvas(elementHTML, {
                        scale: 2,
                        logging: true,
                        useCORS: true,
                    });
                    const imgData = canvas.toDataURL('image/png');

                    // DEBUG
                    console.log(`Captured image[${i + 1}] data:`, imgData);
                    if (!imgData || imgData === "data:,") {
                        console.error(`Captured image[${i + 1}] data is invalid.`);
                        continue; // Skip to the next iteration
                    }

                    // Calculate the width and height of the PDF page
                    const pdfWidth = doc.internal.pageSize.getWidth() - 2 * padding;
                    const pdfHeight = (canvas.height * pdfWidth) / canvas.width;

                    // If adding the next image exceeds the page height, add a new page
                    if (currentY + pdfHeight > pageHeight - padding) {
                        doc.addPage();
                        currentY = padding; // Reset yOffset for the new page
                    }

                    // Add the image to the PDF
                    doc.addImage(imgData, 'PNG', padding, currentY, pdfWidth, pdfHeight);
                    currentY += pdfHeight + 2 * padding; // Increment for next element
                } else {
                    console.warn(`Element with ID ${elementId} not found.`);
                }
            }
        }

        doc.save(fileName);
    } catch (error) {
        console.error('Error exporting elements to PDF:', error);
    }
}

export async function exportChartTableToPdf(headerId, chartId, tableId, fileName) {
    console.log("\n\n\n\n");

    try {
        const { jsPDF } = window.jspdf;
        const doc = new jsPDF({
            orientation: 'landscape',
            unit: 'mm',
            format: 'a4'
        });

        const padding = 20;
        const pdfWidth = doc.internal.pageSize.getWidth() - 2 * padding;

        // Capture the header
        const headerHTML = document.getElementById(headerId);
        if (headerHTML) {
            const headerCanvas = await html2canvas(headerHTML, {
                scale: 2,
                logging: true,
                useCORS: true,
            });
            const headerImgData = headerCanvas.toDataURL('image/png');

            // DEBUG
            console.log('Captured header data:', headerImgData);
            if (!headerImgData || headerImgData === "data:,") {
                console.error('Captured header data is invalid.');
                return;
            }

            const chartWidth = pdfWidth * 1;
            const chartHeight = (headerCanvas.height * chartWidth) / headerCanvas.width;

            // Add the chart page in landscape
            //doc.addPage();
            doc.addImage(headerImgData, 'PNG', padding, 4, chartWidth, chartHeight);
        } else {
            console.warn(`Element with ID ${chartId} not found.`);
            return; // Exit if chart not found
        }

        // Capture the chart
        const chartHTML = document.getElementById(chartId);
        if (chartHTML) {
            const chartCanvas = await html2canvas(chartHTML, {
                scale: 2,
                logging: true,
                useCORS: true,
            });
            const chartImgData = chartCanvas.toDataURL('image/png');

            // DEBUG
            console.log('Captured chart data:', chartImgData);
            if (!chartImgData || chartImgData === "data:,") {
                console.error('Captured chart data is invalid.');
                return;
            }

            const chartWidth = pdfWidth * 1;
            const chartHeight = (chartCanvas.height * chartWidth) / chartCanvas.width;

            // Add the chart page in landscape
            //doc.addPage();
            doc.addImage(chartImgData, 'PNG', padding, 30, chartWidth, chartHeight);
        } else {
            console.warn(`Element with ID ${chartId} not found.`);
            return; // Exit if chart not found
        }

        doc.addPage();

        // Capture the table
        const tableHTML = document.getElementById(tableId);
        if (tableHTML) {
            // Get Number Of Rows
            const rows = tableHTML.getElementsByTagName('tr');
            const rowsCount = rows.length;

            const tableCanvas = await html2canvas(tableHTML, {
                scale: 2,
                logging: true,
                useCORS: true,
            });
            const tableImgData = tableCanvas.toDataURL('image/png');

            // DEBUG
            console.log('Captured table data:', tableImgData);
            if (!tableImgData || tableImgData === "data:,") {
                console.error('Captured table data is invalid.');
                return; // Exit if invalid
            }

            const tableWidth = doc.internal.pageSize.getWidth() * 0.9; // 90% for the table
            const rowHeight = tableCanvas.height / rowsCount;
            const tableHeight = (tableCanvas.height * tableWidth) / tableCanvas.width;
            const availableHeight = doc.internal.pageSize.getHeight() - padding; 

            // Check if the height exceeds page size
            if (tableCanvas.height > availableHeight) {

                const maxRowsPerPage = Math.floor(availableHeight / (rowHeight + padding));
                const numpages = Math.ceil(rowsCount / maxRowsPerPage);

                for (let i = 0; i < numpages; i++) {
                    if (i > 0) {
                        doc.addPage();
                    }

                    const startRow = i * maxRowsPerPage;
                    const rowPossition = (padding + (rowHeight + padding) * (startRow % maxRowsPerPage)) * i;
                    const offset = ((rowPossition * 10) + (10 * i) - (i / 2.85)) - 2;

                    doc.addImage(tableImgData, 'PNG', padding, -offset, tableWidth, tableHeight);
                }
            } else {
                doc.addPage();
                doc.addImage(tableImgData, 'PNG', padding, padding, tableWidth, tableHeight);
            }
        } else {
            console.warn(`Element with ID ${tableId} not found.`);
        }

        // Save the combined PDF
        doc.save(fileName);
    } catch (error) {
        console.error('Error exporting elements to PDF:', error);
    }
}
// - PDF