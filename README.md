# FluxVelocity
Github repository for the project Flux Velocity. 


# Rules  

Rule 0  

The project is written in C++ and will continue to be written in it until further notice.  
It should be noted that the project is allowed to use extra scripting languages like  
Unreal Engine blueprints or lua for small and experimental purposes, however the final  
product should endeavour to convert most of the code base into C++.  

# Section 1 | Coding Style
Rule 1.1

This project will follow Unreal Engine's own Coding Standard to keep consistent between  
API's and Engine features.  
For a detailed run down on the Coding Standard see the [official documentation](https://docs.unrealengine.com/en-US/Programming/Development/CodingStandard/index.html)
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
	* U - Object derived from `UObject`  
	* A - Object derived from `AActor`  
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

Rule 1.5 | Portable C++ Code

Use the follow types instead of the typical types to aid with portability of the code base by being explicit with the with of the type.  
* bool		- booleans (NEVER assume the size f bool)  
* TCHAR		- characters (NEVER assume the size of T  CHAR)
* uint8		- unsigned bytes (1 byte)  
* int8		- signed bytes (1 byte)  
* uint16	- unsigned "shorts" (2 bytes)  
* int16		- signed "shorts" (2 bytes)  
* uint32	- unsigned ints (4 bytes)  
* int32		- signed ints (4 bytes)  
* uint64	- unsigned "quad words" (8 bytes)  
* int64		- signed "quad words" (8 bytes)  
* float		- single precision floating points (4 bytes)  
* double	- single precision floating points (8 byte)  
* PTRINT	- integer that may hold a pointer (NEVER assume the size of PTRINT)  
Note: 
Use of C++'s int and unsigned int types (whose size may vary accross platforms) is  
acceptable in code where integer width is unimportant. Explicitly-sized types must  
still be used in seralized or replicated formats.

Rule 1.6 | Use of Standard Libaries

Unity allows developers to utilize .NET library assemblies when needed. Available libraries can be found here: 
https://docs.unity3d.com/Manual/dotnetProfileAssemblies.html

Rule 1.7 | Comments

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
Note:  
Place the const keyword after the type rather than before the type it points to.  

Rule 1.9 | Example Formatting
UnrealEngine4 uses a system based on JavaDoc to automatically extract comments from  
source code and build documentation, this means there are some specific comment formatting  
rules that need to be followed to facilitate this process.  
  
Two different paramater comment styles are supported.  
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

Rule 1.10 | Modern C++ Language Syntax
Unreal Engine is extremely portable so it is important to keep compiler compability accross platforms.
Unreal Engine uses C++14 language features extensively.
Unless specified below compiler specific language features should be avoided to keep
cross-compatibility.

`static_assert` Keyword
This keyword is valid for use where you need a compile-time assertion.

`override` and `final` Keywords
These keywords are valid for use, and their use is strongly encouraged.

`nullptr` Keyword
This keyword should always used instead of the C-style NULL macro.
The only exception is in C++/C builds (such as for Xbox One).

`auto` Keyword
Generally speaking the `auto` should be avoided.
It is important to be explicit about the type you're initilizing to keep intentions
clear and keep the code readable for fresh eyes.
The same rules apply to the `var` keyword in C# code.
Some exceptions to the rule
* When you bind a lambda to a variable, lammbda types are not easilly  expressible in code.
* For iterator variablesonly when the iterator's type is verbose and impairs readability.
* In template code, where the type of an expression cannot be easilly discerned.
When using auto remember to correctly use `const`, `&`, or `*`.

Ranged-Based For Loop
This type of for-loop is preferred to keep the code easier to understand and more maintainable.
When you migrate code that uses old TMap iterators be aware that the old `Key()` and `Value()`
functions, which were methods of the iterator type are now simply `Key` and `Value` fields
of the underlying key-value `TPair`.

Lambdas and Anonymous Functions
Lambdas can be used freely.
The best lambdas should be no more than a couple statements in length, particularly when used 
as a part of a larger expression or statement,
for example as a predicate in a generic algorithm.
Be aware that stateful lambdas can't be assigned to function pointers, which are used 
extensively in Unreal Engine.
Non-trivial lambdas should be documented in the same manner as regular functions.
Don't be afraid to split them over a few more lines in order to include comment.
Explicit captures should be used rather than automatic capture `[&amp;]` and `[=]`.
This is important for readability, maintainability, and performance reasons, particularly 
when used with large lambdas and deferred execution.
It declares the intent of the author and so mistakes can be more easily be caught
during code review. Incorrect captures can have negative consequences which are more likely to become a problem as the code is maintained over time.
* By*reference capture and by*value capture pointers (including `this` pointer) can cause
accidental dangling references, if execution of the lambda is deferred.
* By*value capture can be a performance concern if it makes unnecessary copies for a non*deferred lambda.
* Accidentally captured `UOject` pointers are invisible to the garbage collector. 
Automatic capture captures `this` pointer implicitly if any member variables are referenced,
even though `[=]` gives the impression of the lambda having its own copies of everything.
Explicit Return types should be used for large lambdas, or when returning the result of 
another function call.
These should be considered in the same way as the `auto` keyword.
Automatic captures and implicit return types are acceptable for trivial, non-deferred lambdas,
such as in `Sort` calls, where the semantics are obvious and being explicit would make it 
overly verbose.
The capture initilize feature from C++ 14 may be used.
Strongly Typed Enumerations
Enum  should always be used as a replacement for old-style namespaced enums, both for regular `enum `and `UENUM`.
These are also supported as UPROPERTYs and replace the old `TEnumAsByte&lt;>` workaround.
However, enums exposed to BLueprints must continue to be based on `uint8`.
Enum classes used as flags can take advantage of the `ENUM_CLASS_FLAGS(EnumType)` macro to
automatically define all of the bitwise operators.
The one exception to this is the use of flags in *truth* context - this is a limitation 
of the language. Instead, all flag enums should have an enumerator called `None` which 
is set to 0 for comparisons.

Move Semantics
All of the main contain types (`TArray`, `TMap`, `TSet`, `FString`) have move constructors and move assignment operators.
These are often used automatically when passing/returning these types by value, but can be explicitly invoked using `MoveTemp`, which is UnrealEngine's equivilent of `std::move`.
Returning containers of strings by value can be a win for expressivity, without the usual cost of temporary copies.
Rules around pass-by-value and use of `MoveTemp` are still being established, but can already be found in some optimized areas of the codebase.

Default Member Initializers
Default member initializers can be used to define the defaults of a class inside the class
itself.
This has the following benefits:
* It does not need to duplicate initializers accross multiple constructors.
* It is not possible to mix the initialization order and declaration order.
* The member type, property flags and default values are all in one place, which helps 
readability and maintainability.
Some of the downsides:
* Any change to the defaults will require a rebuild of all dependent files
* Headers can't change in patch releases engine, so this style can limit the kind of fixes
that are possible. (Engine Dev specific)
* Some things can not be initialized in this way, such as base classes, `UObject sub*objects`,
pointers to forward*declared types, values deduced from constructor arguments, and members 
initialized over multiple steps. TODO(mallchad) figure out what is meant by "steps"
* Putting some initializers in the headers, and the rest in constructors in the .cpp file, 
can reduce readability and maintainability
Use your best judgement when deciding whether to use them.
As a rule of thumb, default member initializers make more sense in game code than 
engine code.
Also consider using config files for default values.

Third Party Code
Whenever you modify the code to a library that we use in the engine be sure to tag your changes with a `//@UE4` comment, as well as an explanation of why you made the change.
This makes merging the changes into a new version of that library easier, and lets 
licensees easily find any modification we have made.
Any third party code included int he engine should be marked with comments formatted to be easily searchable.

Code Formatting

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
For example, do not include `Core.h`, include the specific headers in the `Core.h` that you
need definitions from.
* Try to include every header you need directly, to make fine*grained inclusion easier.
* Do not rely on a header that is included indirectly by another header you include.
 Don't rely on being included through another header, specify everything needed.
* Modules have Private and Public source directories. Definitions needed by other modules 
must be in the headers in the public directory.
Everything else should be in the Private directory. 
Note that in older Unreal modules, these directories may still be called "Src" and "Inc".
Those directories are meant to separate private and public code in the same way and not 
to separate header files from source
* Don't worry about setting up your headers for pre*compiled header generation.
The UnrealBuildTool is excellent at doing this job by itself.
* Split up large functions into logical sub*functions.
One area a compiler can optimize is the elimination of common sub*expressions.
The bigger your functions are, the more work the compiler has to perform to 
identify them.
This inflates build times.
* Don't abuse inline functions.
They force rebuilds even in files which do not use them.
Inline functions should only be used for trivial accessors and when profiling shows there 
is a benefit to doing so.
* Be even more conservative with hte use of `FORCEINLINE`.
All code and local variables will be expanded out into the calling function, and will 
cause the same problems with build times as large functions.

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
* Always use the `TEXT()` macro around string literals.
Otherwise code that constructors `FStrings` from literals will cause undefined behavior.
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
