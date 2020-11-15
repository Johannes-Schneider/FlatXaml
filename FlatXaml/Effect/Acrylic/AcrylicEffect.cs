using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace FlatXaml.Effect.Acrylic
{
    public class AcrylicEffect : ShaderEffect
    {
        public Brush? Input
        {
            get => GetValue(InputProperty) as Brush;
            set
            {
                SetValue(InputProperty, value ?? throw new ArgumentNullException(nameof(Input)));
                UpdateShaderValue(InputProperty);
            }
        }
        
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty(nameof(Input), typeof(AcrylicEffect), 0);

        public Brush RandomInput
        {
            get => (GetValue(RandomInputProperty) as Brush)!;
            set
            {
                SetValue(RandomInputProperty, value ?? throw new ArgumentNullException(nameof(RandomInput)));
                UpdateShaderValue(RandomInputProperty);
            }
        }
        
        public static readonly DependencyProperty RandomInputProperty = RegisterPixelShaderSamplerProperty(nameof(RandomInput), typeof(AcrylicEffect), 1);


        public double Ratio
        {
            get => (double) GetValue(RatioProperty);
            set
            {
                SetValue(RatioProperty, value);
                UpdateShaderValue(RatioProperty);
            }
        }
        
        public static readonly DependencyProperty RatioProperty = DependencyProperty.Register(nameof(Ratio), typeof(double), typeof(AcrylicEffect),
                                                                                              new UIPropertyMetadata(0.15d, PixelShaderConstantCallback(0)));

        public AcrylicEffect()
        {
            var pixelShader = new PixelShader {UriSource = new Uri("pack://application:,,,/FlatXaml;component/Effect/Acrylic/Shader.ps")};
            PixelShader = pixelShader;
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("pack://application:,,,/FlatXaml;component/Effect/Acrylic/Noise.png");
            bitmap.EndInit();
            RandomInput =
                new ImageBrush(bitmap)
                {
                    TileMode = TileMode.Tile,
                    Viewport = new Rect(0, 0, 800, 600),
                    ViewportUnits = BrushMappingMode.Absolute,
                };

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(RandomInputProperty);
            UpdateShaderValue(RatioProperty);
        }
    }
}