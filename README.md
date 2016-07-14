# Task0
Create a plugin library. Plagin is a generic class, where generic`s type is a type, which this class can transform.
Each plugin contains method with parameter of plugin`s generic type and return modified value of the same type.

Example:
 <pre>public string Modify(string param)
 {
    return param.ToLower();
 }
 </pre>
Implement few plugins for build-in types (eg: absolute value for numbers, convert to UTC from local for DateTime, etc).
Create class, that contains a collection of plugins and is a plugin. In this class, the modify method will apply all plugins
from collection to input.

Create a class, that will be a base class for all classes, which will work with plugins. This class must have a generic parameter,
which shows plugin type. Class must has a plugin property, data property and method for data output (eg. Print to
console). Before output, data must be modified by plugin.

Create a class, that will be a plugin and a pluginable at the same time. In it`s Modify method it will modify data by itself
and by plugin (eg. Multiply number by 2 and apply plugin).

Create a simple console demo.
