using System.Collections;

public class ClassDataTest : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", 0 };
        yield return new object[] { "Hola mundo", 2 };
        yield return new object[] { "Saludos a todo Mexico", 4 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}