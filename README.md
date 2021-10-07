#   **HelpersToolbox**

![alt tag](https://raw.githubusercontent.com/turhany/HelpersToolbox/main/img/helperstoolbox.png)  

A set of C# extensions/helpers library

[![NuGet version](https://badge.fury.io/nu/HelpersToolbox.svg)](https://badge.fury.io/nu/HelpersToolbox)

#### Extension Features:
* String Extensions
  * Truncate
  * EqualsWithIgnoreCase
  * ComputeHashSha  
  * IsValidJson
  * IsValidUrl
  * IsValidEmail
  * SanitizeHtml (feyzed on https://github.com/mganss/HtmlSanitizer)
  * Slugify (feyzed on https://github.com/ctolkien/Slugify)
  * FromJson
* Enum Extensions
  * GetDescription
* List Extensions
  * RemoveWhere
  * WhereIf
  * GetPage
* Queryable Extensions
  * WhereIf
  * AddPaging
* Enumerable Extensions
  * Chunk
* Object Extensions
  * GetPropertyValue
  * SetPropertyValue
  * GetPropertyInfo
  * HasProperty  
  * DeepClone
  * ToJson
* Reflection Extensions
  * HasAttribute
  * GetAttribute
* Dictionary Extensions
  * Merge
* Byte Extensions
  * ToEnum
* Int Extensions
  * ToEnum (Int32,Int64)

### Release Notes

#### 1.0.8
* Byte Extensions > ToEnum method added
* Int Extensions > ToEnum method added
#### 1.0.7
* String Extensions > FromJson method added
* Object Extensions > ToJson method added

#### 1.0.6
* String Extensions > Slugify method added
* Object Extensions > DeepClone method usage changed as extension
* Newtonsoft.Json version updated to 13.0.1

#### 1.0.5
* String Extensions > SanitizeHtml method added

#### 1.0.4
* String Extensions > ComputeHashSha method added
* Dictionary Extensions > Merge method added

#### 1.0.3
* Enumerable Extensions > Chunk method added

#### 1.0.2
* List Extensions > GetPage method added
* Queryable Extensions > AddPaging method added

#### 1.0.1
* GetAttribute method moved under the ReflectionExtensions

#### 1.0.0
* Base Release
