// Get the result input field
let result = document.getElementById('result');

// Function to append symbol to the input
function appendSymbol(symbol) {
    result.value += symbol;
}

// Function to clear the result
function clearResult() {
    result.value = '';
}

// Function to delete the last character
function deleteLast() {
    result.value = result.value.slice(0, -1);
}

// Function to calculate the result
function calculate() {
    try {
        result.value = eval(result.value);
    } catch (e) {
        result.value = 'Error';
    }
}