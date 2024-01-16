# JSON unity UI generator.

## SOP :

### Export :

- Attach **EditorScript.cs** to parent canvas game object.
- Inspector should be in _Normal mode_ not in _Debug mode_ to avail this feature.
- After completing UI template creation click **Export UI** button generate _JSON_ file.
- _JSON_ file will be saved in root folder of project. (Note: Same level to Assets folder).

### Import :
- Copy the content in the generated _JSON_ file in Unity project root folder.  
  Paste it **JSON string** text box and then click **Load Data** to load the created template.

## Prerequisite : 
- Unity 2021.3.11f1.

## Used Plugin :
- SimpleJSON for parsing string to JSONNode.