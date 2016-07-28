namespace GenericDependencyProperties.GenericCallback
{
    public delegate bool ValidateValueCallback<in TProperty>(TProperty d);
}
