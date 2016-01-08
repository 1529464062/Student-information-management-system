//传入参数是一个dom对象,获取该对象选中的文本(text)
function getSelectedText(DomNode) {
	if (DomNode.tagName.toUpperCase() == "SELECT") {
		return DomNode.getElementsByTagName("option")[DomNode.selectedIndex].text;
	}
}
//传入参数是一个dom对象,获取该对象选中的值(value)
function getSelectedValue(DomNode) {
	if (DomNode.tagName.toUpperCase() == "SELECT") {
		return DomNode.getElementsByTagName("option")[DomNode.selectedIndex].value;
	}
}