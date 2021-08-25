# FluxVelocity
Github repository for the project Flux Velocity. 


# Rules  

Rule 0  

The project is written in C# and will continue to be written in it until further notice.

# Section 1 | Coding Style
Rule 1.1

This project will follow Unreal Engine's own Coding Standard to keep consistent between  
API's and Engine features.  
For a detailed run down on the Coding Standard see the [official documentation](https://docs.unity3d.com/)
It should be noted that the rules on Class Organization and Copyright Notice should be  
ignored as this project will be using it's own rules

Rule 1.2 | Class Organisation

Classes should be organized with the reader in mind rather than the writer.  
Since most readers will be using the public interface of the class it should be declared  
before any private methods.  
Note that all variable members should be placed before any methods considering that  
they will be the subject of any method calls.  

Rule 1.3 | Copyright Notice

This project has no copyright currently and this section should be ignored. It's a University project, what did you expect? Revenue Share?

Rule 1.4 | Naming Conventions

* The first letter of each word in an type name or variable name should be capitalized.  
For example `UPrimitiveComponent` would be correct
Note, underscores should not be used except in cases where upper case names are using  
and in other scripting languages and their interfaces.
* Type names are prefixed with an additonal upper-case letter to distinguish them from  
variable names.
For example `FSkin` would be a typename whereas Skin is a variable instance of FSkin  
Some prefix letters are reserved by Unreal Engine for specific types.  
	* T - Template classes  
	* I - Classes that are abstract interfaces  
	* E - Enumerations and Enumeration classes  
	* b - Boolean Values  
	* F - Most Other Classes  
Notes:
* Typedefs should be prefixed with the appropriate prefix of the class that is  
being abreviated.
* UnrealHeaderTool requires the correct prefixes in most cases, so it's important to  
provide them.  
* Type and variable names should be nouns.  
Method names are verbs that describe the method's effect, or describe the return  
value of a method that has no effect.  
* Variable, method and class names should aim to be  
clear, unambigious, and descriptive.  
The greater the scope of the name, the greater the important of a good, 
descriptive, name.
* All variables should be declared one at a time, so that a comment on the meaning of  
the variable can also be provided. 
* You can use multi-line or single line comments before a variable.
* A blank line is optional for grouping variables, however, in the place of a  
blank line a header comment should be preferred, describing the name of a group  
* All functions that return a bool should form a question with a true or false answer.   
`IsVisible()` or `ShouldClearBuffer()` are good examples of this.  
* A procedure (a function with no return value) should use a strong verb followed  
by an Object.
An exception is if the Object of the metho is the Object it is in.  
Then the Object is understood from context.  
* Procedures should avoid ambigious names like `Handle` and `Proccess`.
* Optional - It is recommended to prefix function paramater names with `Out` if they  
are passed by reference, and the function is expected to write to that value.  
This makes the intent obvious that the value passed in this argument will be  
modified by the function.  
* If an In or an Out paramater is also a boolean, put the "b" prefix before the In/Out  
Prefix, for example `bOutResult` would be correct.  
* Functions that return a value should describe the return value.  
The name should make clear what the function will return.  
This is particularly important for boolean functions.  
For example, `bool IsTeaFresh(FTea Tea)` is clearer than `bool CheckTea(FTea Tea)`  

Rule 1.5 | Use of Standard Libaries

Unity allows developers to utilize .NET library assemblies when needed. Available libraries can be found here: 
https://docs.unity3d.com/Manual/dotnetProfileAssemblies.html

Rule 1.6 | Comments

Comments are communication and communication is vital.  
* You should aim to write self documenting code. - Rather than write confusing code  
and then comment it well, try to write clearer code that makes the comments redundant.  
* Avoid redundant comments, assume that the reader has a rudimentary understanding  
of the language and of common code snippets do not over explain.  
* Do not contradict the code - comments are important and should be reflective of what  
the code is, accuracy is important for documentation.  
* Write comments for intent - Comments are best written to explain what a block of  
code does and why it does it rather then how it does it, the code should generally  
aim to be be self-explanatory in its execution.  
* Trivial notes like corrections, fixes and todos should be formatted as follows
`TODO(<insert_username>) stuff to do`
Note that more important fixes should be co-ordinates with project-management software and 
other maintainers

Rule 1.8 | Const Correctess

Const is documentation as much as it is a compiler directive, so all code should strive  
to be const-correct to improve readability and performance.
* Pass unmodified function arguments as const - Being explicit in intended usage is  
important in programming so const variables can be used to specify that the  
function will not modify the arguments  
* Flag unmodifying methods with const - If a method is not intended to modify the  
calling object, make it explicit to specify intent and reduce misuse of the method.  
* Use const iteration for read-only iteration - If an iteration is not meant to allow the  
data to be modified externally then specify it to prevent misuse.
* Prefer const by-value function paramaters - This helps a reader understand that a variable  
is not, and should not be modified in a function.
Note: Move sematics that involve the paramater in an exception to this rule
* Never const a return type - Doing so inhibits compiler move semantics and will cause  
compiler warnings for built-in types  
Note: This only applies to the type itself and not a dereferenced object  
Note: Place the const keyword after the type rather than before the type it points to.  

Rule 1.9 | Example Formatting
It's recommended to follow the type of code standards demonstrated below. 
The `@param` style is the traditional multi-line style, but for simple functions  
it can be clearer to integrate the paramater and return value documentation into  
a single, descriptive comment for the function.  
Below are two examples.  

	/**
     * Calculate a delta-taste value for the tea given the volume and temperature of water used to steep.
     * @param VolumeOfWater - Amount of water used to brew in mL
     * @param TemperatureOfWater - Water temperature in Kelvins
     * @param OutNewPotency - Tea's potency after steeping starts, from 0.97 to 1.04
     * @return The change in intensity of the tea in tea taste units (TTU) per minute
     */
    float Steep(
        const float VolumeOfWater,
        const float TemperatureOfWater,
        float& OutNewPotency
    );
	/** Adds a sweetener to the tea, quantified by the grams of sucrose that would produce the same sweetness. */
    void Sweeten(const float EquivalentGramsOfSucrose);
* Include method comments once - Method comments should only be included once where  
the method is publicly declared, the comment should only contain information relevant to  
the caller and not inner workings about the method, such comments about the workings  
of the function should be contained within the method body.  
* Class Comments - A class comment should include a description of the  
problem that it solves and why it was created.
* Function Comments - A function comment should describe what problem it solves, the comment  
should describe intent and not how it is implemented
* Paramater Comments - A parameter comment should include the units of measured,
the range of expected values, what values are "impossible" and the meaning of status/error codes
* Return Comments - A return comment should document the expected return value, in the 
same way an output variable is documented. Avoid redundancy and do not write the return comment if it is specified in the function purpose
* Extra Information -`@warning` `@note` `@see` `@deprecated` tags can optionally be used to document additional relaant information. Each should be declared on their own lines
TODO(mallchad) move part of this section back into Section 1.7

Rule 1.9 | Code Formatting

Brace wars are foul.
Epic has a long standing usage pattern of putting braces on a new line.
Please adhere to that usage.
Always include braces in single-statement blocks

If-Else
Each block of execution in an if-else statement should be in braces.
This is to prevent editing mistakes - when braces are not used, somebody could 
unwittingly add another line to an if block. 
The extra line would not be controlled by the if expression, which would be a problem.
It is also a problem when conditionally compiled items cause if/else statements to break.
Always use braces.
A multi-way if statement should be intended with each else if intended the same amount as 
the first if, this makes the structure clear to a reader.
Tabs and Indenting
Here are the standards for indenting your code:
* Indent code by execution block.
* Use white-space characters, never use tabs. 
Tell you editor to input exactly 4 characters.

Switch Stat ements
Except for empty cases (multiple cases having identical code), switch case statements 
should explicitly label that a case falls through to the next case, or include a 
"falls-through" comment in each case.
Other code control-transfer commands (return, continue, ect...) are fine as well.
Always have a default case and include a break just in case someboy adds a new case after the default.

Namespaces
You can use namespaces to organize your classes, functions and variables where appropriate.
If you do use them, follow the rules below:
* Most Unreal Engine code is currently not wrapped in a global namespace.
Be careful to avoid collisions in the global scope, especially when using or 
including third party code.
* Namespaces are not supported by UnrealHeaderTool, so they should not be used when 
defining `UCLASS`s, `USCRUCT`s and so on.
* New APIs which aren't `UCLASS`s and such should be placed in a `UE::` namespace at least.
Ideally in a nested namespace like `UE::Audio`.
Namespaces which are used to hold implimentation details which are not part of the public*facing API should go in a private namespace like `UE:Audio::Private`.
* Using declarations - *Do not put `using` declarations int he global scope, even in a 
.cpp file. It will cause problems with the "unity" build system.
	*It is ok to put using declarations within another namespace, or within a function body.
	*If you put using declarations within a namespace, this will carry over to other 
	occurrences of that namespace in the smae translation unity. 
	As long as you are consistent, this is fine.
	*z You can only use using declarations in header files safely if you follow the above rules
* Note that forward*declared types need to be declared within their respective namespace.
Failing to do so will cause linker errors.
* If you declare a very large amount of classes/types within a namespace, it can be 
difficult to use those types in other global*scoped classes.
For example, function signatures will need to use explicit namespace when appearing 
in class definitions.
* `using` declarations should only be used to alias specific variables within a namespace.
This is not common in Unreal code.
* Macros cannot live in a namespace, however it should be prefixed with `UE_`instead

Physical Dependencies
* File names should not be prefixed where possible.
This is simply to make using tools like file finders easier.
* All headers should protect against multiple includes with the `#pragma once` directive.
All compilers used by Unreal Engine support the directive.
* In general, try to minimize physical coupling.
In particular, avoid including standard library headers from other headers.
* If you can use forward declarations instead of including a header, do so.
* When including, be as fine grained as possible.
* Try to include every header you need directly, to make fine*grained inclusion easier.
* Do not rely on a header that is included indirectly by another header you include.
 Don't rely on being included through another header, specify everything needed.
Those directories are meant to separate private and public code in the same way and not 
to separate header files from source
One area a compiler can optimize is the elimination of common sub*expressions.
The bigger your functions are, the more work the compiler has to perform to 
identify them.
This inflates build times.

Encapsulation
Enforce encapsulation with the protection keywords.
Class member should almost always be declared private unless they are part of the 
public/protected interface to he class.
Use your judgement, note that a lack of accessors can make refactoring hard without breaking 
plugins and existing projects.
If particular fields are only intended to be usable by derived classes then make them 
private and provide protected accessors.
Use final if your class is not designed to be derived from.

General Style Issues
* Minimize dependency distance.
When code depends on a particular variables value, try to set that variable just before 
using it.
Initializing a variable and not using it for a long time gives lots of opportunity for 
something to accidentally modify the value, breaking your code.
Having it on the next line makes it clear why the variable's use clear.
* Split methods into sub*methods where possible.
It aids gauging the bigger picture and working towards the interesting details.
It is simpler to understand a simple method that calls other sub*methods than a single 
large method that contains all the code.
* In function declaration or function call sites do not add a space between the name and the 
argument parenthesis.
* Address compiler warnings.
Compiler warning messages mean something is wrong.
Fix what the compiler is warning you about.
If it cannot be addressed, use `#pragma` to suppress the warning, however this is a last 
resort.
* Leave a blank line at he end of the file. All .cpp and .h files should include a blank line,
to coordinate with gcc.
* Debug code should either be generally useful and polished, or not checked in.
Debug code that is intermixed with other code makes the other code harder to read.
* Avoid repeating the same operation redundantly in loops.
Move common sub*expressions out of loops to avoid redundant calculations.
Sometimes the use of static variables is OK to avoid redundant operations such as large 
object construction.
*Be mindful of hot reloading.
Minimize dependencies to cut down on iteration time.
Don't use inlining or templates for functions which are likely to change over a reload.
Only use statics for things which are expected to remain constant over a reload.
* Use intermediate variables to simplify complicated expressions.
Complicated expressions can be easier to understand if split into smaller sub*expressions 
that are assigned to intermediate variables, with descriptive names.
* Pointers and references should only have one space to the right of the type.
This makes it more easy to search for references and pointers of a given type.
* Shadowed variables are not allowed.
Shadowed variables create ambiguity and make the code harder to understand.
* Avoid anonymous literals in function calls.
Prefer named constants which describe their meaning.

API Design Guidelines
* `bool` function parameters should be avoided, particular for flags passed to functions.
This also has the same problem as the anonymous literal.
They also tend to multiply over time as APIs get extended with more behavior.
Instead, prefer an enum.
This prevents transposing of flags, accidental conversion, and removes the need to repeat 
redundant defaults, it is also more efficient.
Booleans are acceptable as arguments when they are the complete state to be passe to a function like a setter.
Although consider refactoring if this chances.
* Avoid long function paramater lists.
If a function requires many parameters consider passing a dedicated struct.
* Avoid overloading functions by `bool` and `FString`, this can cause undefined behavior.
* Interface classes should always be abstract and not have member variables.
They are allowed to contain methods that are not virtual or static as long as they are 
implemented inline.
* Use the `virtual` and `override` keywords when declaring an overriding method.
When declaring a virtual function in a derived class that overrides a virtual function, 
both `virtual` and `override` keywords must be used.

Platform-Specific Code
Platform-specific code should always be abstract and implemented in platform-specific 
source files.
In general you should avoid adding any uses of `PLATFORM_<platform_name>` to code outside 
of a directory named `<platform>`
Instead, extend the hardware abstraction layer to add a static function.
Platforms can then override this function, returning either a platform-specific constant 
value or even using platform APIs to determine the result.
If you force-inline the function it will have the same performance characteristics as 
using a define.
In cases where a define is absolutely necessary, create new `#define`s that describe 
particular properties that can apply to a platform.
Centralizing the platform-specific details of the engine allow for such details to be 
contained entirely within platform-specific source files.
This makes it easier to maintain the engine across multiple platforms and also to port 
the code to new platforms without he need to scour the codebase for platform-specific 
defines.
Keeping code in platform-specific folders is also a requirement for NDA platforms,
such as PS4, XBOne and Nintendo Switch.
It is important to ensure the code compiles and runs reguardless of whether the 
platform-specific sub-directory is present.

# Section 2 | The Project and Source Control
Rule 2.1 | GitHub
* The master branch is considered stable/release and should always have a working prototype.
* Best practices is to branch off from the master or development branch and start working
on a feature-branch.
* Never work on the master branch directly, bad things happen then.
* Avoid force-pushing to any branch, ideally create a new branch and push to that.
* If you are the sole person working on the branch (check beforehand) then it is OK sometimes 
to force-push to that branch.
* Seek review before pulling anything to another branch.
(note this will not always possible so use the best judgment at the time).
This kind of work-flow allows multiple features to be developed simultaneously without 
interfering with important aspects like project compilation.
