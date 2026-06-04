namespace BMI_Calculator;

public partial class BMICalculator : ContentPage
{
	private string selectedGender = "";
	public BMICalculator()
	{
		InitializeComponent();
	}

	private void MaleTapped(object? sender, EventArgs e)
	{
		selectedGender = "Male";
		GenderLabel.Text = "Selected Gender: Male";

		MaleBorder.Stroke = Colors.DodgerBlue;
		FemaleBorder.Stroke = Colors.Transparent;

		MaleImage.Opacity = 1;
		FemaleImage.Opacity = .5;

		


	}

	private void FemaleTapped(object? sender, EventArgs e)
	{
		selectedGender = "Female";
		GenderLabel.Text = "Selected Gender: Female";

		FemaleBorder.Stroke = Colors.LightPink;
		MaleBorder.Stroke = Colors.Transparent;

		FemaleImage.Opacity = 1;
		MaleImage.Opacity = .5;

		

	}

	private void SliderValueChanged(object? sender, EventArgs e)
	{
		WeightLabel.Text = $"Weight: {(int)WeightSlider.Value} lbs";
		HeightLabel.Text = $"Height: {(int)HeightSlider.Value} inches";
	

	}

    private async void CalculateBMIClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(selectedGender))
        {
            await DisplayAlert("Missing Info", "Please select a gender first.", "OK");
            return;
        }

        double weight = WeightSlider.Value;
        double height = HeightSlider.Value;
        double bmi = (weight * 703) / (height * height);
        string status = GetBMIStatus(bmi);
        string recommendation = GetRecommendation(status);

        await DisplayAlert(
            "Your calculated BMI results are:",
            $"Gender: {selectedGender}\n" +
            $"BMI: {bmi:F0}\n" +
            $"Health Status: {status}\n" +
            $"Recommendations:\n- {recommendation}",
            "Ok");
    }


    
	private string GetBMIStatus(double bmi)
	{
		if (selectedGender == "Male")
		{
			if (bmi < 18.5)
				return "Underweight";
			else if (bmi < 25)
				return "Normal weight";
			else if (bmi < 30)
				return "Overweight";
			else
				return "Obese";
		}
		else
		{
            if (bmi < 18)
                return "Underweight";
            else if (bmi < 24)
                return "Normal weight";
            else if (bmi < 29)
                return "Overweight";
            else
                return "Obese";
        }
	}

	private string GetRecommendation(string status)
	{
        switch (status)
        {
            case "Underweight":
                return "Increase calorie intake with nutrient-rich foods such as nuts, lean protein, and whole grains. Incorporate strength training to build muscle mass. Consult a nutritionist if needed.";

            case "Normal weight":
                return "Maintain a balanced diet with proteins, healthy fats, and fiber. Stay physically active with at least 150 minutes of exercise per week. Keep regular check-ups to monitor overall health.";

            case "Overweight":
                return "Reduce processed foods and focus on portion control. Engage in regular aerobic exercises such as jogging or swimming, and include strength training. Drink plenty of water and track your progress.";

            case "Obese":
                return "Consult a doctor for personalized guidance. Start with low-impact exercises such as walking or cycling. Follow a structured weight-loss meal plan and consider behavioral therapy for lifestyle changes. Avoid sugary drinks and maintain a consistent sleep schedule.";

            default:
                return "Enter your information to receive a recommendation.";
        }


    }

}