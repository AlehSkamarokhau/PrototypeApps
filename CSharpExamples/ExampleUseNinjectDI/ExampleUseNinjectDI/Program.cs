using System;

using Ninject;
using Ninject.Modules;

namespace ExampleUseNinjectDI
{
	interface IApple
	{
		string Color { get; set; }

		string Condition { get; set; }
	}

	class Apple : IApple
	{
		public string Color { get; set; }

		public string Condition { get; set; }
	}

	class Tree
	{
		private IApple _apple;

		public IApple Apple
		{
			get { return _apple; }
			set { _apple = value; }
		}

		public Tree(IApple apple)
		{
			if (apple == null)
			{
				throw new ArgumentNullException("apple");
			}

			_apple = apple;
		}
	}

	public class TreeModule : NinjectModule
	{
		public override void Load()
		{
			Bind<IApple>().To<Apple>();
			Bind<Tree>().ToSelf().InSingletonScope();
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = new StandardKernel(new TreeModule());

			Tree myTree = kernel.Get<Tree>();

			myTree.Apple.Color = "Red";
			myTree.Apple.Condition = "Good";

			Console.WriteLine("Apple Color: {0} Apple Condition: {1}", myTree.Apple.Color, myTree.Apple.Condition);

			Console.ReadLine();
		}
	}
}
