package de.gdxtest;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.assets.loaders.ModelLoader;
import com.badlogic.gdx.graphics.*;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g3d.*;
import com.badlogic.gdx.graphics.g3d.attributes.ColorAttribute;
import com.badlogic.gdx.graphics.g3d.environment.DirectionalLight;
import com.badlogic.gdx.graphics.g3d.loader.G3dModelLoader;
import com.badlogic.gdx.graphics.g3d.utils.ModelBuilder;
import com.badlogic.gdx.utils.JsonReader;

public class SuperMain extends ApplicationAdapter {


	private Camera cam;
	private ModelBatch mBatch;
	private ModelBuilder mBuilder;
	private Model mod;
	private ModelInstance model;
	private Environment env;

	
	@Override
	public void create () {
		float scale = 50.f / Gdx.graphics.getHeight();
		cam = new OrthographicCamera(Gdx.graphics.getWidth()*scale, Gdx.graphics.getHeight()*scale);

		//cam = new PerspectiveCamera(75, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
		//cam.position.set(1f, 1f, 1f);
		cam.position.set(10, 10, 10);
		cam.lookAt(0, 0, 0);
		//cam.setToOrtho(true, Gdx.graphics.getWidth(), Gdx.graphics.getHeight());
		cam.near = .1f;
		cam.far = 50;

		mBatch = new ModelBatch();
		mBuilder = new ModelBuilder();

		/*
		 */
		mod = mBuilder.createBox(3, 3, 3,
				new Material("TestBoxMat", ColorAttribute.createDiffuse(Color.RED)),
				VertexAttributes.Usage.Position|
						VertexAttributes.Usage.Normal);
		ModelLoader ml = new G3dModelLoader(new JsonReader());
		mod = ml.loadModel(Gdx.files.internal("core/assets/drone.g3dj"));




		model = new ModelInstance(mod, 0, 0, 0);
		//model.transform.scale(10, 10, 10);

		env = new Environment();
		env.set(new ColorAttribute(ColorAttribute.AmbientLight, 0.4f, 0.4f, 0.4f, 1f));
		env.add(new DirectionalLight().set(0.8f, 0.8f, 0.8f, -1f, -0.8f, -0.2f));
	}

	@Override
	public void render () {
		Gdx.gl.glClearColor(0, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT | GL20.GL_DEPTH_BUFFER_BIT);

		cam.update();
		mBatch.begin(cam);
		mBatch.render(model, env);
		mBatch.end();
	}
	
	@Override
	public void dispose () {

	}
}
