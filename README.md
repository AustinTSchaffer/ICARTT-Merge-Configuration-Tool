# ICARTT-Merge-Configuration-Tool

Repository for the ICARTT Merge Configuration Tool, a GUI for configuring series of ICARTT data merges. Property of NASA Langley Research Center.

This application is currently unfinished, but defines a structure for a process, split up into several sub-processes. Each subprocess is governed by a a subclass of _ProcessControl_, each with a specific function. Each Process Control will only gather and modify information from memory, so no Process Control can send information directly to another Process Control. This way, sub-processes have a logical ordering, but some can be skipped or performed out of order.

### Currently Implemented Sub-Processes

__Directory Select__

This sub-process allows the user to select a parent directory for all of the data files that will be included in the merge. The control has a currently deactivated second field, which would allow the user to select a previously generated configuration file in addition to a parent directory. The purpose of this additional control is listed under __Optional Additional Utilities__.


__File Name Filters__

This sub-process allows the user to filter the input files based on the names of the files. ICARTT data files have required fields in their file names, each separated by underscores. The titles of these fields are (in order of appearance):

* Data ID
* Location ID
* Date (YYYYMMDD[hhmmss:mmm])
* Revision Number
* Launch Number (Optional)
* Volumne Number (Optional)
* Comments (Optional)

This sub-process allows the user to select a single Location ID. For this location ID, the user will be able to choose a series of Data IDs that will be merged into each resulting merge file. The user may also choose a series of dates. These three fields are used, because (a) each location ID has many data IDs, (b) each data ID has many dates, and (c) one resulting merged data file will contain information from a single date, but multiple data IDs, under a single location ID.


__File Select__

This sub-process shows all of the ICARTT files contained in the selected parent directory as a checked list. This sub-process also displays some available metadata for each file. A file will appear unchecked if it was removed from the merge by the previous sub-process. The user may further add or remove files from the merge.


__Time Variable Selection__

This sub-process allows the user to select the time variables associated with input files. The control attempts to prepopulate the start, stop, and mid time variables for each Data ID, based on the names of the first 3 variables of each file. All ICARTT files need either (a) at least two of these variable specifications or (b) one of these variable types and a valid data interval.


### Currently Unimplemented Sub-Processes


__Map Variables__

At this point in the process all non-time variables can be grouped based on their enclosing data ID. This sub-process, or series of sub-processes, must allow the user to:

* create a list of output varialbes
* assign an ordering to the list of output variables
* assign each variable a type from a predetermined list and populate the metadata associated with the type
* assign each output variable a list of associated input variables


__Generate Output Header__

This sub-process must have utilities for generating a series of output headers in accordance with the most recent iteration of the ICARTT file format specification. Some header information, such as the list of contained variables and fields that show a number of lines, should be generated automatically. Any fields that can be populated by the user must be broken into their relavent sub-sections, such as Normal Comments, Special Comments, output file names, contact information, etc. All user populated fields must support replaceable text. The replaceable text specification is defined in the PDF and DOCX titled _Offline ICARTT Merge Configuration Specification_, but can be changed.


__Populate Date-Specific Text__

This sub-process will allow the user to populate the specific text that will replace the previously specified replaceaple text. Each date of a merge will require its own set of replaceable text. The replaceable text specification is defined in the PDF and DOCX titled _Offline ICARTT Merge Configuration Specification_, but can be changed.


__Generate Configuration File__

This is the final sub-process of the application. Here, the application will generate an output configuration file from all of the information that was processed by all previous Process Controls. The schema of this output XML is defined in the PDF and DOCX titled _Offline ICARTT Merge Configuration Specification_.


### Optional Additional Utilities

__Edit Previous Configuration__

One requested feature for this application is a utility that will allow users to load in a previously generated configuration XML. This should allow users to load a previously created list of output variables and prepopulate a mapping from input variables to output variables.


### Contact Info

__Austin Schaffer__
austin.schaffer.11@cnu.edu
703-258-9423

__Michael Shook__
michael.a.shook@nasa.gov

__Gao Chen__
gao.chen@nasa.gov
