using System;

namespace FactoryMethodExamples
{
    // 1) Абстрактний продукт
    public interface ITransport
    {
        void Deliver();
    }

    // 2) Конкретні продукти
    public class Truck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка вантажівкою.");
        }
    }

    public class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Доставка кораблем.");
        }
    }

    // 3) Абстрактний творець
    public abstract class Logistics
    {
        public void PlanDelivery()
        {
            ITransport transport = CreateTransport();
            transport.Deliver();
        }

        public abstract ITransport CreateTransport();
    }

    // 4) Конкретні творці
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    // 5) Платіжна система
    public interface IPayment
    {
        void ProcessPayment();
    }

    public class CardPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Обробка оплати карткою.");
        }
    }

    public class PayPalPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Оплата через PayPal.");
        }
    }

    public abstract class PaymentFactory
    {
        public abstract IPayment CreatePayment();
    }

    public class CardPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment() => new CardPayment();
    }

    public class PayPalPaymentFactory : PaymentFactory
    {
        public override IPayment CreatePayment() => new PayPalPayment();
    }

    // 6) Фігури
    public interface IShape
    {
        void Draw();
    }

    public class Circle : IShape
    {
        public void Draw() => Console.WriteLine("Малюю коло.");
    }

    public class Square : IShape
    {
        public void Draw() => Console.WriteLine("Малюю квадрат.");
    }

    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();
    }

    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape() => new Circle();
    }

    public class SquareFactory : ShapeFactory
    {
        public override IShape CreateShape() => new Square();
    }

    // 7) Сховище
    public interface IStorage
    {
        void Save(string content);
    }

    public class FileStorage : IStorage
    {
        public void Save(string content)
        {
            Console.WriteLine($"Зберігаю у файл: {content}");
        }
    }

    public class CloudStorage : IStorage
    {
        public void Save(string content)
        {
            Console.WriteLine($"Зберігаю в хмару: {content}");
        }
    }

    public abstract class StorageFactory
    {
        public abstract IStorage CreateStorage();
    }

    // 8) Тестування
    public abstract class TestCase
    {
        public void RunTest()
        {
            object testObject = CreateTestObject();
            Console.WriteLine("Тестування об’єкта: " + testObject.GetType().Name);
        }

        protected abstract object CreateTestObject();
    }

    public class User
    {
        // Приклад простого класу користувача
    }

    public class UserTest : TestCase
    {
        protected override object CreateTestObject()
        {
            return new User();
        }
    }

    // Програма для демонстрації
    class Program
    {
        static void Main()
        {
            Logistics logistics = new RoadLogistics();
            logistics.PlanDelivery();

            PaymentFactory paymentFactory = new PayPalPaymentFactory();
            IPayment payment = paymentFactory.CreatePayment();
            payment.ProcessPayment();

            ShapeFactory shapeFactory = new CircleFactory();
            IShape shape = shapeFactory.CreateShape();
            shape.Draw();

            StorageFactory storageFactory = new StorageFactoryImpl();
            IStorage storage = storageFactory.CreateStorage();
            storage.Save("Документ");

            TestCase test = new UserTest();
            test.RunTest();
        }
    }

    // Допоміжна фабрика для зберігання
    public class StorageFactoryImpl : StorageFactory
    {
        public override IStorage CreateStorage() => new CloudStorage();
    }
}
