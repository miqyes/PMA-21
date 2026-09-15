namespace Task4;
public class Vector {
    double x{ get; }
    double y { get; }
    double z { get; }
    public Vector(double x, double y, double z) {
        this.x = x;
        this.y = y;
        this.z = z; }

    public static Vector operator +(Vector vec1, Vector vec2) {
        return new Vector(
            vec1.x + vec2.x,
            vec1.y + vec2.y,
            vec1.z + vec2.z); }
    
    public static Vector operator -(Vector vec1, Vector vec2) {
        return new Vector(
            vec1.x - vec2.x,
            vec1.y - vec2.y,
            vec1.z - vec2.z); }
    
    public static Vector operator *(Vector vec, double number) {
        return new Vector(
            vec.x * number,
            vec.y * number,
            vec.z * number); }
    
    public static Vector operator /(Vector vec, double number) {
        if (number == 0)
            throw new DivideByZeroException();
        return new Vector(
            vec.x/ number,
            vec.y / number,
            vec.z / number); }
    
    public override string ToString() {
        return $"({x};{y};{z})"; } }