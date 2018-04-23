# Web Report Designer - How to open a report with an untyped DataSet as a data source 


Currently, <a href="https://msdn.microsoft.com/en-us/library/esbykkzb(v=vs.110).aspx">strongly typed DataSets</a> <strong>are serialized, </strong>while untyped are not. <br /><br />Obviously, this behavior produces incorrect results if you save/load a report layout to/from XML. <br /><br />Since the Web Report Designer works with the XML report representation, incorrect results may be also produced when loading a report which an untyped data set as a data source.<br /><br />To resolve this, we need to serialize an untyped data source. <br />To do so, implement a custom serializer which implements the DevExpress.XtraReports.Native.IDataSerializer interface and use the XML-serialization capabilities exposed by the DataSet class to serialize/deserialize this data set as follows. <br /><br />In the IDataSerializer.Serialize method, serialize a DataSet into XML through the <a href="http://msdn.microsoft.com/en-us/library/sa57x5f2%28v=vs.110%29.aspx">DataSet.WriteXml</a> method.<br />In the IDataSerializer.Deserialize method, create a new DataSet instance and populate it from a properly formatted XML stream by using the <a href="http://msdn.microsoft.com/en-us/library/55hehd8c%28v=vs.110%29.aspx">DataSet.ReadXml</a> method. <br /><br />See also:<br /><a href="https://www.devexpress.com/Support/Center/p/T269534">How to serialize a report to XML with an untyped DataSet as a data source</a>

<br/>


