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
            // Ensure that newWidth is within the bounds of the container
            const clampedHeight = Math.min(Math.max(newHeight, 0), containerRect.height - splitBar.offsetHeight);
            leftPanel.style.height = clampedHeight + 'px';
            rightPanel.style.height = (containerRect.height - clampedHeight - splitBar.offsetHeight) + 'px';
        } else {
            const newWidth = e.clientX - containerRect.left;
            // Ensure that newWidth is within the bounds of the container
            const clampedWidth = Math.min(Math.max(newWidth, 0), containerRect.width - splitBar.offsetWidth);
            leftPanel.style.width = clampedWidth + 'px';
            rightPanel.style.width = (containerRect.width - clampedWidth - splitBar.offsetWidth) + 'px';
        }
    }
}

function endResize(e) {
    isResizing = false;
    document.removeEventListener('mousemove', handleMouseMove);
    document.removeEventListener('mouseup', endResize);
}
