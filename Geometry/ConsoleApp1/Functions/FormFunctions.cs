using Geometry.Model;

namespace Geometry.Fucntion;

public delegate bool FormPredicat(Form f);

public static class Forms
{
    public static IEnumerable<Form> Filter(IEnumerable<Form> sourse, FormPredicat predicat)
    {
        // la fonction anonyme et le couteau suisse pour faire passer ce que l'on souhaite
        return sourse.Where((f) => predicat(f));
    }

    //filter by type en générique
    // TODO IEnumarable<U> filterByType<T, U>(IEnumarable<T> source) 
}