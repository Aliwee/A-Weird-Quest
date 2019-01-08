using System.Collections;
using System.Collections.Generic;

public class Achievement {
	/// <summary>
	/// Initializes a new instance of the <see cref="Achievement"/> class.
	/// </summary>
	/// <param name="num">Number.</param>
	/// <param name="status">If set to <c>true</c> status.</param>
	public Achievement(int num, bool status){
		this.num = num;
		this.status = status;
	}

	public int num { get; set;}

	public bool status { get; set;}
}
