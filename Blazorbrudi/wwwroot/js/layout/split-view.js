let leftPanel, rightPanel, splitBar, container;
let isResizing = false;
let resizeHorizontal = false;

export function startResize(containerRef, horizontal)
{
    container = containerRef;
    leftPanel = container.querySelector(".split-content--first");
    rightPanel = container.querySelector(".split-content--second");
    splitBar = container.querySelector(".split-bar");
    resizeHorizontal = horizontal;
    isResizing = true;
    document.addEventListener('mousemove', handleMouseMove);
    document.addEventListener('mouseup', endResize);
}

function handleMouseMove(e) {
    if (isResizing) {
        const containerRect = container.getBoundingClientRect();
        if (resizeHorizontal) {
            const newHeight = e.clientY - containerRect.top;
            leftPanel.style.height = newHeight + 'px';
            rightPanel.style.height = (containerRect.height - newHeight - splitBar.offsetHeight) + 'px';
        } else {
            const newWidth = e.clientX - containerRect.left;
            leftPanel.style.width = newWidth + 'px';
            rightPanel.style.width = (containerRect.width - newWidth - splitBar.offsetWidth) + 'px';
        }
    }
}

function endResize(e) {
    isResizing = false;
    document.removeEventListener('mousemove', handleMouseMove);
    document.removeEventListener('mouseup', endResize);
}
