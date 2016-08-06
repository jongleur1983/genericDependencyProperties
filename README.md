# genericDependencyProperties
experiments towards using Generics in .NET DependencyProperties

DependencyProperties are a central component of the WPF architecture.
The underlying DependencyProperties are untyped - or better: all of type object, 
but usually any user of a DependencyProperty has to cast that object to the target type and back whenever accessing the property.

Dealing with DependencyProperties in WPF means to deal with (more or less unsave) type casts and involves much duplicated code in any new DependencyProperty.
This project aims to reduce that by utilizing Generics to enhance the DependencyProperty system.

## Milestone 1
As a first milestone the underlying Data should stay the same, but Registration should be possible in a generic way.

## Ideas for the future
Is it possible to replace the existing DependencyProperty system entirely by a type-safe alternative?
The biggest challenge with that is going to be how DependencyProperties are used by the WPF libraries, as those would have to be compatible with the generic system as well.
