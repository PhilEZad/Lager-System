pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'cd Backend/API'
                sh 'dotnet restore .'
                sh 'dotnet build API.csproj'
                echo 'build complete'
            }
        }
        stage('Test') {
            steps {
                //
                echo 'test'
            }
        }
        stage('Deploy') {
            steps {
                //
                echo 'deploy'
            }
        }
    }
}