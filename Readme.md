<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128604812/15.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T269524)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/DXApplication1/WebEUD/Default.aspx) (VB: [Default.aspx](./VB/DXApplication1/WebEUD/Default.aspx))
* [Default.aspx.cs](./CS/DXApplication1/WebEUD/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/DXApplication1/WebEUD/Default.aspx.vb))
* [Global.asax](./CS/DXApplication1/WebEUD/Global.asax) (VB: [Global.asax](./VB/DXApplication1/WebEUD/Global.asax))
* [Global.asax.cs](./CS/DXApplication1/WebEUD/Global.asax.cs) (VB: [Global.asax.vb](./VB/DXApplication1/WebEUD/Global.asax.vb))
* [CustomUntypedDataSetSerializer.cs](./CS/DXApplication1/WebEUD/Helpers/CustomUntypedDataSetSerializer.cs) (VB: [CustomUntypedDataSetSerializer.vb](./VB/DXApplication1/WebEUD/Helpers/CustomUntypedDataSetSerializer.vb))
* [DataHelpers.cs](./CS/DXApplication1/WebEUD/Helpers/DataHelpers.cs) (VB: [DataHelpers.vb](./VB/DXApplication1/WebEUD/Helpers/DataHelpers.vb))
* [DataSourceInitializer.cs](./CS/DXApplication1/WebEUD/Helpers/DataSourceInitializer.cs) (VB: [DataSourceInitializer.vb](./VB/DXApplication1/WebEUD/Helpers/DataSourceInitializer.vb))
<!-- default file list end -->
# Web Report Designer - How to open a report with an untyped DataSet as a data source 


Currently, <a href="https://msdn.microsoft.com/en-us/library/esbykkzb(v=vs.110).aspx">strongly typed DataSets</a> <strong>are serialized, </strong>while untyped are not. <br /><br />Obviously, this behavior produces incorrect results if you save/load a report layout to/from XML. <br /><br />Since the Web Report Designer works with the XML report representation, incorrect results may be also produced when loading a report which an untyped data set as a data source.<br /><br />To resolve this, we need to serialize an untyped data source. <br />To do so, implement a custom serializer which implements the DevExpress.XtraReports.Native.IDataSerializer interface and use the XML-serialization capabilities exposed by the DataSet class to serialize/deserialize this data set as follows. <br /><br />In the IDataSerializer.Serialize method, serialize a DataSet into XML through the <a href="http://msdn.microsoft.com/en-us/library/sa57x5f2%28v=vs.110%29.aspx">DataSet.WriteXml</a> method.<br />In the IDataSerializer.Deserialize method, create a new DataSet instance and populate it from a properly formatted XML stream by using the <a href="http://msdn.microsoft.com/en-us/library/55hehd8c%28v=vs.110%29.aspx">DataSet.ReadXml</a> method. <br /><br />See also:<br /><a href="https://www.devexpress.com/Support/Center/p/T269534">How to serialize a report to XML with an untyped DataSet as a data source</a>

<br/>


