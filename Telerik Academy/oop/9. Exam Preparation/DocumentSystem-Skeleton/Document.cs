using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class Document : IDocument
{
    private string name;
    private string content;

    public string Name
    {
        get { return name; }
    }

    public string Content
    {
        get { return content; }
        protected set { content = value; }
    }

    public Document(string name, string content = null)
    {
        this.name = name;
        this.content = content;
    }

    public virtual void LoadProperty(string key, string value) { }
    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output) {}

    protected virtual PropertyInfo[] GetSortedProperties()
    {
        var sorted = this.GetType().GetProperties().OrderBy(x => x.Name);
        return sorted.ToArray<PropertyInfo>();
    }

    protected virtual string GetPropertiesString() 
    {
        PropertyInfo[] props = GetSortedProperties();
        StringBuilder propsBuilder = new StringBuilder();

        foreach (PropertyInfo prop in props)
        {
            var value = prop.GetValue(this, null);

            if (value != null)
            {
                propsBuilder.Append(prop.Name.ToLower() + "=" + value + ";");
            }
        }

        return propsBuilder.ToString();
    }
}
